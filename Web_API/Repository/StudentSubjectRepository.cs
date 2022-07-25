using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;
using Web_API.IRepository;

namespace Web_API.Repository
{
    public class StudentSubjectRepository: IStudentSubjectReponsitory
    {
        private readonly Context _context;

        public StudentSubjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentSubject>> GetList()
        {
            return await _context.StudentSubjects.ToListAsync();
        }

        public async Task<StudentSubject> GetById(int id)
        {
            return await _context.StudentSubjects.FindAsync(id);
        }

        public async Task<StudentSubject> Create(StudentSubject studentSbSubject)
        {
            await _context.StudentSubjects.AddAsync(studentSbSubject);
            await _context.SaveChangesAsync();
            return studentSbSubject;
        }

        public async Task<StudentSubject> Update(StudentSubject studentSbSubject)
        {
            _context.StudentSubjects.Update(studentSbSubject);
            await _context.SaveChangesAsync();
            return studentSbSubject;
        }

        public async Task<StudentSubject> Delete(StudentSubject studentSbSubject)
        {
            _context.StudentSubjects.Remove(studentSbSubject);
            await _context.SaveChangesAsync();
            return studentSbSubject;
        }
    }
}
