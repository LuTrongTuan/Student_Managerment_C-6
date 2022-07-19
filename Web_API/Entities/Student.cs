using System.Collections.Generic;
using Web_API.Enums;

namespace Web_API.Entities
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}