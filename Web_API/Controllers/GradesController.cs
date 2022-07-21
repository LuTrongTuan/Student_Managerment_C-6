using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Entities;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeRepository _maGradeRepository;

        public GradesController(IGradeRepository maGradeRepository)
        {
            _maGradeRepository = maGradeRepository;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return Ok(await _maGradeRepository.GetList());
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _maGradeRepository.GetById(id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(grade);
        }
        // POST: api/Grades
        [HttpPost]
        public async Task<IActionResult> PostGrade(Grade grade)
        {

            var grades = await _maGradeRepository.Create(grade);

            return CreatedAtAction("GetGrade", new { id = grade.GradeId }, grades);
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }
            var gradeForm = await _maGradeRepository.GetById(id);
            if (gradeForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            gradeForm.Name = grade.Name;
            gradeForm.Status = grade.Status;
            gradeForm.MajorId = grade.MajorId;
            return Ok(await _maGradeRepository.Update(gradeForm));
        }
        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _maGradeRepository.GetById(id);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(await _maGradeRepository.Delete(grade));
        }
    }
}
