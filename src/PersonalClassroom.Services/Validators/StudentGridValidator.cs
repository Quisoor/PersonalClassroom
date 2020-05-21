using FluentValidation;
using PersonalClassroom.Database;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Tools;
using System.Linq;

namespace PersonalClassroom.Services.Validators
{
    public class StudentGridValidator : BaseValidator<StudentGridModel>
    {
        private readonly PcContext context;

        public StudentGridValidator(PcContext context, ErrorService errorService) : base(errorService)
        {
            this.context = context;
            RuleFor(x => x.Firstname).NotNull().NotEmpty();
        }

        public override void OnInsert()
        {
            RuleFor(x => x.Id).Null();
        }

        public override void OnUpdate()
        {
            RuleFor(x => x.Id).NotNull().Must(x => context.Students.Any(y => y.Id == x.Value));
        }

        public override void OnDelete()
        {
            RuleFor(x => x.Id).NotNull().Must(x => context.Students.Any(y => y.Id == x.Value));
        }
    }
}
