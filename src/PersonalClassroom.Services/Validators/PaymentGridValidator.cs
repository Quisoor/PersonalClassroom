using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Tools;

namespace PersonalClassroom.Services.Validators
{
    public class PaymentGridValidator : BaseValidator<PaymentGridModel>
    {
        private readonly PcContext context;

        public PaymentGridValidator(PcContext context, ErrorService errorService) : base(errorService)
        {
            this.context = context;
        }

        public override void OnDelete()
        {
            RuleFor(x => x.Id).NotNull().MustAsync(async (x, token) => await context.Payments.AnyAsync(y => y.Id == x, token));
        }
    }
}
