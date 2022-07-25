using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.StudentDto;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var student = await _studentRepository.GetList();
            var students = student.Select(x => new StudentViewModel()
            {
                Id = x.StudentId,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                Email = x.Email,
                Gender = x.Gender,
                MajorId = x.MajorId,
                GradeId = x.GradeId
            });
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = await _studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(new StudentViewModel()
            {
                Id = student.StudentId,
                Name = student.Name,
                Phone = student.Phone,
                Address = student.Address,
                Email = student.Email,
                Gender = student.Gender,
                MajorId = student.MajorId,
                GradeId = student.GradeId
            });
        }
        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentForm = await _studentRepository.GetById(id);
            if (studentForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            studentForm.Name = studentViewModel.Name;
            studentForm.Address = studentViewModel.Address;
            studentForm.Email = studentViewModel.Email;
            studentForm.Gender = studentViewModel.Gender;
            studentForm.Phone = studentViewModel.Phone;
            studentForm.Status = studentViewModel.Status;
            studentForm.MajorId = studentViewModel.MajorId;
            studentForm.GradeId = studentViewModel.GradeId;
            var result = await _studentRepository.Update(studentForm);
            return Ok(new StudentViewModel()
            {
                Id = result.StudentId,
                Name = result.Name,
                Phone = result.Phone,
                Address = result.Address,
                Email = result.Email,
                Gender = result.Gender,
                MajorId = result.MajorId,
                GradeId = result.GradeId
            });
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentViewModel studentViewModel)
        {
            
            var students = await _studentRepository.Create(new Student()
            {
                StudentId = studentViewModel.Id,
                Name = studentViewModel.Name,
                Phone = studentViewModel.Phone,
                Address = studentViewModel.Address,
                Email = studentViewModel.Email,
                Gender = studentViewModel.Gender,
                MajorId = studentViewModel.MajorId,
                GradeId = studentViewModel.GradeId
            });
            return CreatedAtAction("GetStudent", new { id = students.StudentId }, students);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            var result = await _studentRepository.Delete(student);
            return Ok(result);
        }
    }
}
