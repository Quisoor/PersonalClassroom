using System.Collections.Generic;

namespace PersonalClassroom.Database.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int? LevelId { get; set; }
        public Level Level { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<StudentPayment> StudentPayments { get; set; }
    }
}
