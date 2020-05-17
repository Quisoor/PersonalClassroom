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
    public class PaymentGridService
    {
        private readonly PcContext context;
        private readonly PaymentGridValidator validator;
        private readonly IMapper mapper;

        public PaymentGridService(PcContext context, PaymentGridValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public IEnumerable<PaymentGridModel> Get()
        {
            var query = context.Payments
                .Include(x => x.StudentPayments)
                .OrderBy(x => x.Date);
            return mapper.ProjectTo<PaymentGridModel>(query);
        }

        public async Task<IEnumerable<PaymentGridModel>> GetAsync(CancellationToken cancellationToken = default)
        {
            var query = context.Payments
                .Include(x => x.StudentPayments)
                .OrderBy(x => x.Date);
            return await Task.Run(() => mapper.ProjectTo<PaymentGridModel>(query), cancellationToken);
        }

        public async Task<IList<ValidationFailure>> DeleteAsync(PaymentGridModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateDeleteAsync(model, cancellationToken);
            if (result.IsValid)
            {
                var entity = await context.Payments
                    .Where(x => x.Id == model.Id.Value)
                    .SingleAsync(cancellationToken);
                context.Payments.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
            }
            return result.Errors;
        }
    }
}
