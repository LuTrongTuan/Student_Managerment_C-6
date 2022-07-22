using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Data;
using Example.IReponsitory;
using Example.Models;
using Microsoft.EntityFrameworkCore;
namespace Example.Reponsitory
{
    public class MajorsRepository : IMajorsRepository

    {
        private readonly Context _context;


        public MajorsRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Majors>> GetList()
        {
            return await _context.Majors.ToListAsync();
        }

        public async Task<Majors> GetById(int id)
        {
            return await _context.Majors.FindAsync(id);
        }

        public async Task<Majors> Create(Majors majors)
        {
            await _context.AddAsync(majors);
            await _context.SaveChangesAsync(); 
            return majors;
        }

        public async Task<Majors> Update(Majors majors)
        {
            _context.Majors.Update(majors);
            await _context.SaveChangesAsync();
            return majors;
        }

        public async Task<Majors> Delete(Majors majors)
        {
            _context.Majors.Remove(majors);
            await _context.SaveChangesAsync();
            return majors;
        }
    }
}