using System.Collections.Generic;
using Example.Enums;

namespace Example.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public double Summary { get; set; }
        public Status? Status { get; set; }
        public ICollection<Student>? Student { get; set; }
    }
}