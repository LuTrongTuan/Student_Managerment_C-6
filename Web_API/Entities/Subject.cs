using System.Collections.Generic;
using Web_API.Enums;

namespace Web_API.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public double Summary { get; set; }
        public Status? Status { get; set; }
        public int TranScripId { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}