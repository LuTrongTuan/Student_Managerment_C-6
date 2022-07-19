using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Repository
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly Context _context;

        public SubjectRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subject>> GetList()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<Subject> Create(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> Update(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> Delete(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
    }
}