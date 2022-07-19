using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Repository
{
    public class GradeRepository:IGradeRepository
    {
        private readonly Context _context;

        public GradeRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Grade>> GetList()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetById(int id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task<Grade> Create(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> Update(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> Delete(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return grade;
        }
    }
}