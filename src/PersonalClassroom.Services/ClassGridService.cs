using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class ClassGridService
    {
        private readonly PcContext context;
        private readonly ClassGridValidator validator;
        private readonly IMapper mapper;

        public ClassGridService(PcContext context, ClassGridValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public IEnumerable<ClassGridModel> Get()
        {
            var query = context.Classes.OrderBy(x => x.Start);
            return mapper.ProjectTo<ClassGridModel>(query);
        }

        public async Task<IEnumerable<ClassGridModel>> GetAsync(CancellationToken cancellationToken)
        {
            var query = context.Classes.OrderBy(x => x.Start);
            return await Task.Run(() => mapper.ProjectTo<ClassGridModel>(query), cancellationToken);
        }

        public async Task<IList<ValidationFailure>> DeleteAsync(ClassGridModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateDeleteAsync(model, cancellationToken);
            if (result.IsValid)
            {
                var entity = await context.Classes
                    .Where(x => x.Id == model.Id.Value)
                    .SingleAsync(cancellationToken);
                context.Classes.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
            }
            return result.Errors;
        }
    }
}
