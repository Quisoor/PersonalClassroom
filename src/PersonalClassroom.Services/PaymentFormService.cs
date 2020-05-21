using FluentValidation.Results;
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
    public class PaymentFormService
    {
        private readonly PcContext context;
        private readonly PaymentFormValidator validator;

        public PaymentFormService(PcContext context, PaymentFormValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public async Task InsertAsync(PaymentFormModel model, CancellationToken cancellationToken = default)
        {
            var result = await validator.ValidateInsertAsync(model);
            if (result.IsValid)
            {
                var payment = new Payment
                {
                    Date = model.Date.Value,
                    Price = model.Price.Value,
                    LeftToUse = model.Price.Value,
                    StudentPayments = model.StudentIds.Select(x => new StudentPayment { StudentId = x }).ToList()
                };
                context.Payments.Add(payment);
                var classesToPay = context.Classes
                    .OrderBy(x => x.Start)
                    .AsEnumerable()
                    .Where(x => x.LeftToPay > 0)
                    .Where(x => payment.StudentPayments.Any(y => y.StudentId == x.StudentId))
                    .ToList();
                var i = 0;
                while (payment.LeftToUse > 0 && i < classesToPay.Count)
                {
                    var classItem = classesToPay[i];
                    var diff = payment.LeftToUse >= classItem.LeftToPay ? classItem.LeftToPay : payment.LeftToUse - classItem.LeftToPay;
                    classItem.LeftToPay -= Math.Abs(diff);
                    payment.LeftToUse -= Math.Abs(diff);
                    i++;
                }
                await context.Payments.AddAsync(payment, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
