using System;
using System.Collections.Generic;

namespace PersonalClassroom.Services.Models
{
    public class PaymentFormModel
    {
        public PaymentFormModel()
        {
            StudentIds = new List<int>();
        }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public List<int> StudentIds { get; set; }
    }
}
