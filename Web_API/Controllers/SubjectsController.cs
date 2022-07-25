using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.SubjectDto;
using Microsoft.AspNetCore.Mvc;
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
            var subject = await _subjectRepository.GetList();
            var subjects = subject.Select(c => new SubjectViewModel()
            {
                SubjectId = c.SubjectId,
                Name = c.Name,
                Status = c.Status,
                SchoolId = c.SchoolId
            });
            return Ok(subjects);
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

            return Ok(new SubjectViewModel()
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Summary = subject.Summary,
                Status = subject.Status,
                SchoolId = subject.SchoolId
            });
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var subjectForm = await _subjectRepository.GetById(id);
            if (subjectForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            subjectForm.Name = subjectViewModel.Name;
            subjectForm.Summary = subjectViewModel.Summary;
            subjectForm.Status = subjectViewModel.Status;
            subjectForm.SchoolId = subjectViewModel.SchoolId;
            var result = await _subjectRepository.Update(subjectForm);
            return Ok(new SubjectViewModel()
            {
                SubjectId = result.SubjectId,
                Name = result.Name,
                Summary = result.Summary,
                Status = result.Status,
                SchoolId = result.SchoolId
            });
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var subjects = await _subjectRepository.Create(subjectViewModel);
            var subjects = await _subjectRepository.Create(new Subject()
            {
                SubjectId = subjectViewModel.SubjectId,
                Name = subjectViewModel.Name,
                Summary = subjectViewModel.Summary,
                Status = subjectViewModel.Status,
                SchoolId = subjectViewModel.SchoolId
            });

            return CreatedAtAction("GetSubject", new { id = subjects.SubjectId }, subjects);
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
