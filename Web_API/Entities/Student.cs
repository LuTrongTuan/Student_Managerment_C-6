using System.Collections.Generic;
using DTO.Enums;

namespace Web_API.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public Status Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int? MajorId { get; set; }
        public Majors Major { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public List<StudentSubject> StudentSubject { get; set; }
    }
}