using System;

namespace PersonalClassroom.Services.Models
{
    public class ClassGridModel
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? StudentId { get; set; }
        public decimal? Price { get; set; }
        public decimal? LeftToPay { get; set; }
    }
}
