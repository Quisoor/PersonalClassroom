using FluentValidation;
using PersonalClassroom.Models;
using System.Linq;

namespace PersonalClassroom.Validators
{
    public class PaymentFormValidator : AbstractValidator<PaymentForm>
    {
        public PaymentFormValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.StudentIds).Must(x => x.Any());
        }
    }
}
