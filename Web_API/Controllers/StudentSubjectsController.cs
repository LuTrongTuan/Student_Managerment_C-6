using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;
using Web_API.IRepository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : ControllerBase
    {
        private readonly IStudentSubjectReponsitory _studentSubjectReponsitory;

        public StudentSubjectsController(IStudentSubjectReponsitory studentSubjectReponsitory)
        {
            _studentSubjectReponsitory = studentSubjectReponsitory;
        }

        // GET: api/StudentSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSubject>>> GetStudentSubjects()
        {
            var studentSubject = await _studentSubjectReponsitory.GetList();
            var result = studentSubject.Select(c => new StudentSubjectViewModel()
            {
                Id = c.Id,
                SubjectId = c.SubjectId,
                StudentId = c.StudentId
            });

            return Ok(result);
        }

        // GET: api/StudentSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSubject>> GetStudentSubject(int id)
        {
            var studentSubject = await _studentSubjectReponsitory.GetById(id);

            if (studentSubject == null)
            {
                return NotFound();
            }

            return Ok(new StudentSubjectViewModel()
            {
                Id = studentSubject.Id,
                StudentId = studentSubject.StudentId,
                SubjectId = studentSubject.SubjectId
            });
        }

        // PUT: api/StudentSubjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSubject(int id, StudentSubjectViewModel studentSubjectViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var studentSubjectForm = await _studentSubjectReponsitory.GetById(id);
            if (studentSubjectForm == null)
            {
                    return NotFound($"{id} is not fond");
            }
            studentSubjectForm.StudentId = studentSubjectViewModel.StudentId;
            studentSubjectForm.SubjectId = studentSubjectViewModel.SubjectId;
            var result = await _studentSubjectReponsitory.Update(studentSubjectForm);
                
            return Ok(new StudentSubjectViewModel()
            {
                Id = result.Id,
                StudentId = result.StudentId,
                SubjectId = result.SubjectId
            });
        }

        // POST: api/StudentSubjects
        [HttpPost]
        public async Task<ActionResult<StudentSubject>> PostStudentSubject(StudentSubjectViewModel studentSubjectViewModel)
        {
            var result = await _studentSubjectReponsitory.Create(new StudentSubject()
            {
                Id = studentSubjectViewModel.Id,
                StudentId = studentSubjectViewModel.StudentId,
                SubjectId = studentSubjectViewModel.SubjectId
            });

            return CreatedAtAction("GetStudentSubject", new { id = result.Id }, result);
        }

        // DELETE: api/StudentSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSubject(int id)
        {
            var studentSubject = await _studentSubjectReponsitory.GetById(id);
            if (studentSubject == null)
            {
                return NotFound();
            }
            return Ok(await _studentSubjectReponsitory.Delete(studentSubject));
        }

    }
}
