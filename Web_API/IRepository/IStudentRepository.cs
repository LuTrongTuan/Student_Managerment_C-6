using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetList();
        Task<Student> GetById(int id);
        Task<Student> Create(Student student);
        Task<Student> Update(Student student);
        Task<Student> Delete(Student student);
    }
}