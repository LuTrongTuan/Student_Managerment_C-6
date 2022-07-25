using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.IRepository
{
    public interface IStudentSubjectReponsitory
    {
        Task<IEnumerable<StudentSubject>> GetList();
        Task<StudentSubject> GetById(int Id);
        Task<StudentSubject> Create(StudentSubject studentSbSubject);
        Task<StudentSubject> Update(StudentSubject studentSbSubject);
        Task<StudentSubject> Delete(StudentSubject studentSbSubject);
    }
}
