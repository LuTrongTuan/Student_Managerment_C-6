using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentSubjectViewModel
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
    }
}
