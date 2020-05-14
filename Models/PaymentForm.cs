using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalClassroom.Models
{
    public class PaymentForm
    {
        public PaymentForm()
        {
            StudentIds = new List<int>();
        }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public List<int> StudentIds { get; set; }
    }
}
