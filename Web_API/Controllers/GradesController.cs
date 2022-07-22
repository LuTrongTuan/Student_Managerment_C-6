using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.GradeDto;
using Microsoft.AspNetCore.Mvc;
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
            var grade = await _maGradeRepository.GetList();
            var grades = grade.Select(x => new GradeViewModel()
            {
                Id = x.GradeId,
                Name = x.Name,
                Status = x.Status,
                MajorId = x.SchoolId
            });
            return Ok(grades);
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

            return Ok(new GradeViewModel()
            {
                Id = grade.GradeId,
                Name = grade.Name,
                Status = grade.Status,
                MajorId = grade.SchoolId
            });
        }
        // POST: api/Grades
        [HttpPost]
        public async Task<IActionResult> PostGrade(GradeViewModel gradeViewModel)
        {

            var grades = await _maGradeRepository.Create(new Grade()
            {
                GradeId = gradeViewModel.Id,
                Name = gradeViewModel.Name,
                Status = gradeViewModel.Status,
                SchoolId = gradeViewModel.MajorId
            });

            return CreatedAtAction("GetGrade", new { id = grades.GradeId }, grades);
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, GradeViewModel gradeViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var gradeForm = await _maGradeRepository.GetById(id);
            if (gradeForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            gradeForm.Name = gradeViewModel.Name;
            gradeForm.Status = gradeViewModel.Status;
            gradeForm.SchoolId = gradeViewModel.MajorId;
            var grads = await _maGradeRepository.Update(gradeForm);
            return Ok(new GradeViewModel()
            {
                Id = grads.GradeId,
                Name = grads.Name,
                Status = grads.Status,
                MajorId = grads.SchoolId
            });
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
