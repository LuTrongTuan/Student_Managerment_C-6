using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Web_API.Enums;

namespace Web_API.Entities
{
    public class Majors
    {
        [Key]
        public int MajorId { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public ICollection<Grade>? Grade { get; set; }
    }
}