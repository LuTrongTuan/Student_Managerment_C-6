using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Models;


namespace Example.IReponsitory
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