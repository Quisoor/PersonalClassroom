﻿using System;
using System.Collections.Generic;

namespace PersonalClassroom.Database.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal LeftToUse { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<StudentPayment> StudentPayments { get; set; }
    }
}
