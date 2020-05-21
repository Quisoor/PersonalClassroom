using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class ErrorService
    {
        // Can be called from anywhere
        public async Task AddErrors(List<ValidationFailure> errors)
        {
            if (Notify != null && errors.Any())
            {
                await Notify.Invoke(errors);
            }
        }

        public event Func<List<ValidationFailure>, Task> Notify;
    }
}
