using System.Collections.Generic;
using Web_API.Enums;

namespace Web_API.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public ICollection<Majors>? Major { get; set; }
    }
}