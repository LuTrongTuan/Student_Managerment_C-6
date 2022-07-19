using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Repository
{
    public class SchoolRepository : ISchoolRepository

    {
        private readonly Context _context;

        public SchoolRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<School>> GetList()
        {
            return await _context.Schools.ToListAsync();
        }
        public async Task<School> GetById(int id)
        {
            return await _context.Schools.FindAsync(id);
        }
        public async Task<School> Create(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> Delete(School school)
        {
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return school;
        }
        public async Task<School> Update(School school)
        {
            _context.Schools.Update(school);
            await _context.SaveChangesAsync();
            return school;
        }
    }
}