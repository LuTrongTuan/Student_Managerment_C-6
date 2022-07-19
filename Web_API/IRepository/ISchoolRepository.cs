using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.Repository
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<School>> GetList();
        Task<School> GetById(int id);
        Task<School> Create(School school);
        Task<School> Update(School school);
        Task<School> Delete(School school);
    }
}