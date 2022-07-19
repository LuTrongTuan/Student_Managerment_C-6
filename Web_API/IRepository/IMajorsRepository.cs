using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.Entities;

namespace Web_API.Repository
{
    public interface IMajorsRepository
    {
        Task<IEnumerable<Majors>> GetList();
        Task<Majors> GetById(int id);
        Task<Majors> Create(Majors majors);
        Task<Majors> Update(Majors majors);
        Task<Majors> Delete(Majors majors);
    }
}