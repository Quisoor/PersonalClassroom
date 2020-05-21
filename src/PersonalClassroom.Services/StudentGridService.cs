using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class StudentGridService
    {
        private readonly PcContext context;
        private readonly IMapper mapper;
        private readonly StudentGridValidator validator;

        public StudentGridService(PcContext context, IMapper mapper, StudentGridValidator validator)
        {
            this.context = context;
            this.mapper = mapper;
            this.validator = validator;
        }

        public IEnumerable<StudentGridModel> Get()
        {
            var query = context.Students.AsQueryable();
            return mapper.ProjectTo<StudentGridModel>(query);
        }

        public async Task<IEnumerable<StudentGridModel>> GetAsync(CancellationToken cancellationToken = default)
        {
            var query = context.Students.AsQueryable();
            return await Task.Run(() => mapper.ProjectTo<StudentGridModel>(query), cancellationToken);
        }

        public async Task InsertAsync(StudentGridModel model, CancellationToken cancellationToken = default)
        {
            var entity = mapper.Map<Student>(model);
            await context.Students.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(StudentGridModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateUpdateAsync(model, cancellationToken);
            if (result.IsValid)
            {
                var entity = mapper.Map<Student>(model);
                var existingEntity = await context.Students
                    .Where(x => x.Id == model.Id.Value)
                    .SingleAsync(cancellationToken);
                mapper.Map(existingEntity, entity);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(StudentGridModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateDeleteAsync(model, cancellationToken);
            if (result.IsValid)
            {
                var entity = await context.Students
                    .Where(x => x.Id == model.Id.Value)
                    .SingleAsync(cancellationToken);
                context.Students.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
