using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PersonalClassroom.Database;
using PersonalClassroom.Database.Entities;
using PersonalClassroom.Services.Models;
using PersonalClassroom.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services
{
    public class ClassFormService
    {
        private readonly PcContext context;
        private readonly ClassFormValidator validator;

        public ClassFormService(PcContext context, ClassFormValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public async Task InsertAsync(ClassFormModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateInsertAsync(model, cancellationToken);
            if (result.IsValid)
            {
                var entitiesToAdd = new List<Class>();
                var paymentsToUse = context.Payments
                    .Include(x => x.StudentPayments)
                    .AsEnumerable()
                    .Where(x => x.LeftToUse > 0)
                    .Where(x => x.StudentPayments.Any(x => x.StudentId == model.StudentId))
                    .ToList();
                for (var date = model.StartDate.Value; date <= model.EndDate.Value; date = date.AddDays(1))
                {
                    if (model.Days.Any(y => y.Number == date.DayOfWeek))
                    {
                        var start = date;
                        var startHour = TimeSpan.Parse(model.StartHour);
                        start = start.AddTicks(startHour.Ticks);
                        var classItem = new Class
                        {
                            Description = model.Description,
                            Duration = TimeSpan.Parse(model.Duration),
                            Price = model.Price.Value,
                            LeftToPay = model.Price.Value,
                            Start = start,
                            StudentId = model.StudentId.Value
                        };
                        while (paymentsToUse.Any(x => x.LeftToUse > 0) && classItem.LeftToPay > 0)
                        {
                            var payment = paymentsToUse.First();
                            var diff = Math.Abs(payment.LeftToUse >= classItem.LeftToPay ? classItem.LeftToPay : payment.LeftToUse - classItem.LeftToPay);
                            payment.LeftToUse -= diff;
                            classItem.LeftToPay -= diff;
                        }
                        entitiesToAdd.Add(classItem);
                    }
                }
                await context.AddRangeAsync(entitiesToAdd, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
