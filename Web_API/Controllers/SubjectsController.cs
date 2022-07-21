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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            return Ok(await _subjectRepository.GetList());
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _subjectRepository.GetById(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var subjectForm = await _subjectRepository.GetById(id);
            if (subjectForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            subjectForm.Name = subject.Name;
            subjectForm.Summary = subject.Summary;
            subjectForm.Status = subject.Status;
            var result = await _subjectRepository.Update(subjectForm);
            return Ok(result);
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var subjects = await _subjectRepository.Create(subject);
            return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subjects);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }

            var result = _subjectRepository.Delete(subject);
            return Ok(result);
        }
    }
}
