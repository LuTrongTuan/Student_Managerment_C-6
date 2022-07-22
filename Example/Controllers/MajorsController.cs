using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Example.Data;
using Example.IReponsitory;
using Example.Models;

namespace Example.Controllers
{
    public class MajorsController : Controller
    {
        private readonly Context _context;
        private readonly IMajorsRepository _majorsRepository;

        public MajorsController(Context context, IMajorsRepository majorsRepository)
        {
            _context = context;
            _majorsRepository = majorsRepository;
        }

        // GET: Majors
        public async Task<IActionResult> Index()
        {
            var context = _context.Majors.Include(m => m.School);
            return View(await context.ToListAsync());
        }

        // GET: Majors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majors = await _context.Majors
                .Include(m => m.School)
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (majors == null)
            {
                return NotFound();
            }

            return View(majors);
        }

        // GET: Majors/Create
        public IActionResult Create()
        {
            ViewData["SchoolId"] = new SelectList(_context.Schools, "SchoolId", "Name");
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MajorId,Name,Status,SchoolId")] Majors majors)
        {
            if (ModelState.IsValid)
            {
                await _majorsRepository.Create(majors);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchoolId"] = new SelectList(_context.Schools, "SchoolId", "Name", majors.SchoolId);
            return View(majors);
        }

        // GET: Majors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majors = await _context.Majors.FindAsync(id);
            if (majors == null)
            {
                return NotFound();
            }
            ViewData["SchoolId"] = new SelectList(_context.Schools, "SchoolId", "Name", majors.SchoolId);
            return View(majors);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MajorId,Name,Status,SchoolId")] Majors majors)
        {
            if (id != majors.MajorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(majors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MajorsExists(majors.MajorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SchoolId"] = new SelectList(_context.Schools, "SchoolId", "Name", majors.SchoolId);
            return View(majors);
        }

        // GET: Majors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majors = await _context.Majors
                .Include(m => m.School)
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (majors == null)
            {
                return NotFound();
            }

            return View(majors);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var majors = await _context.Majors.FindAsync(id);
            _context.Majors.Remove(majors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajorsExists(int id)
        {
            return _context.Majors.Any(e => e.MajorId == id);
        }
    }
}
