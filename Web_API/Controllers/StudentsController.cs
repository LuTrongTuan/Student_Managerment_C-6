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
            return Ok(await _studentRepository.GetList());
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

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentForm = await _studentRepository.GetById(id);
            if (studentForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            studentForm.Name = student.Name;
            studentForm.Address = student.Address;
            studentForm.Email = student.Email;
            studentForm.Gender = student.Gender;
            studentForm.Phone = student.Phone;
            studentForm.Status = student.Status;
            var result = await _studentRepository.Update(studentForm);
            return Ok(result);
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var students = await _studentRepository.Create(student);
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, students);
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
