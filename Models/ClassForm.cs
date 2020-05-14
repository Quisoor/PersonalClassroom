using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalClassroom.Models
{
    public class ClassForm
    {
        public ClassForm()
        {
            Days = new List<Day>();
        }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StudentId { get; set; }
        public IEnumerable<Day> Days { get; set; }
        public string StartHour { get; set; }
        public string Duration { get; set; }        
    }
}
