using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;

namespace Web_API.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly Context _context;
        public StudentRepository(Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetList()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(string studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<Student> Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}