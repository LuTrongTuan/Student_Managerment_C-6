using System.Collections.Generic;
using DTO.Enums;

namespace Web_API.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public List<Majors>? Major { get; set; }
        public List<Grade>? Grade { get; set; }
        public List<Subject>? Subject { get; set; }
    }
}