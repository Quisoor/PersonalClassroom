using FluentValidation;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Tools;
using System.Linq;

namespace PersonalClassroom.Services.Validators
{
    public class PaymentFormValidator : BaseValidator<PaymentFormModel>
    {
        public override void OnInsert()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.StudentIds).Must(x => x.Any());
        }
    }
}
