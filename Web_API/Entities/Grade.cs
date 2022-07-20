using System.Collections.Generic;
using Web_API.Enums;

namespace Web_API.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public int MajorId { get; set; }
        public Majors Major { get; set; }
        public ICollection<Student>? Student { get; set; }
    }
}