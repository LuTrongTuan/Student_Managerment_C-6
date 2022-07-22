using System.Collections.Generic;
using Example.Enums;
using Example.Models;


namespace Example.Models
{
    public class Majors
    {
        public int MajorId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public ICollection<Grade>? Grade { get; set; }
    }
}