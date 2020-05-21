using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Tools;

namespace PersonalClassroom.Services.Validators
{
    public class ClassGridValidator : BaseValidator<ClassGridModel>
    {
        private readonly PcContext context;

        public ClassGridValidator(PcContext context, ErrorService errorService) : base(errorService)
        {
            this.context = context;
        }

        public override void OnDelete()
        {
            RuleFor(x => x.Id).NotNull().MustAsync(async (x, token) => await context.Classes.AnyAsync(y => y.Id == x.Value, token));
            RuleFor(x => x.LeftToPay).Equal(x => x.Price);
        }
    }
}
