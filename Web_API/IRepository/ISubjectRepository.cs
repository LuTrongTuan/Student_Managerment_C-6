using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.Repository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetList();
        Task<Subject> GetById(int id);
        Task<Subject> Create(Subject subject);
        Task<Subject> Update(Subject subject);
        Task<Subject> Delete(Subject subject);
    }
}