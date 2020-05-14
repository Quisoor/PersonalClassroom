using DevExpress.Blazor;
using System;

namespace PersonalClassroom.Database.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal LeftToPay { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsPayed => LeftToPay == 0;
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
