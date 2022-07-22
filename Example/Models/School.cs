using System.Collections.Generic;
using Example.Enums;

namespace Example.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public ICollection<Majors>? Major { get; set; }
    }
}