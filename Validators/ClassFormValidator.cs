using FluentValidation;
using PersonalClassroom.Models;
using System;
using System.Linq;

namespace PersonalClassroom.Validators
{
    public class ClassFormValidator : AbstractValidator<ClassForm>
    {
        public ClassFormValidator()
        {
            RuleFor(x => x.Days).Must(x => x.Any()).WithMessage("Veuillez sélectionner au moins un jour de la semaine.");
            RuleFor(x => x.Duration).NotNull().NotEmpty();
            RuleFor(x => x.Duration).Must(x => TimeSpan.TryParse(x, out TimeSpan result)).WithMessage("La durée doit être au format HH:mm.");
            RuleFor(x => x.StartHour).NotNull().NotEmpty();
            RuleFor(x => x.StartHour).Must(x => TimeSpan.TryParse(x, out TimeSpan result)).WithMessage("L'heure de début doit être au format HH:mm.");
            RuleFor(x => x.StartDate).NotNull();
            RuleFor(x => x.EndDate).NotNull().GreaterThanOrEqualTo(x => x.StartDate);
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.StudentId).NotNull();
        }
    }
}
