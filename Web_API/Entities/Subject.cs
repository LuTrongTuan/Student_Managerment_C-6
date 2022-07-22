﻿using System.Collections.Generic;
using DTO.Enums;

namespace Web_API.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public double Summary { get; set; }
        public Status Status { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
        public List<StudentSubject>? StudentSubject { get; set; }
    }
}