using System;
using System.Collections.Generic;

namespace PersonalClassroom.Services.Models
{
    public class PaymentGridModel
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public List<int?> ForStudentIds { get; set; }
    }
}
