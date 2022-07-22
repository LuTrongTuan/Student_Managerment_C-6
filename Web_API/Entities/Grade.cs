﻿using System.Collections.Generic;
using DTO.Enums;

namespace Web_API.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public List<Student> Student { get; set; }
    }
}