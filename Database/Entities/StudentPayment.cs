using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalClassroom.Database.Entities
{
    public class StudentPayment
    {
        public int StudentId { get; set; }
        public int PaymentId { get; set; }
        public Student Student { get; set; }
        public Payment Payment { get; set; }
    }
}
