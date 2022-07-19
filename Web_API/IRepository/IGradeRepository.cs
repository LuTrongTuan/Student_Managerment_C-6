using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.Repository
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetList();
        Task<Grade> GetById(int id);
        Task<Grade> Create(Grade grade);
        Task<Grade> Update(Grade grade);
        Task<Grade> Delete(Grade grade);
    }
}