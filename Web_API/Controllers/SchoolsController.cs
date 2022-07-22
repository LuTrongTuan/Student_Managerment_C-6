using System.Linq;
using System.Threading.Tasks;
using DTO.Enums;
using DTO.SchoolDto;
using Microsoft.AspNetCore.Mvc;
using Web_API.Entities;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolRepository _iSchoolRepository;

        public SchoolsController(ISchoolRepository iSchoolRepository)
        {
            _iSchoolRepository = iSchoolRepository;
        }

        //List
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var school = await _iSchoolRepository.GetList();
            var schools = school.Select(x => new SchoolViewModel()
            {
                Id = x.SchoolId,
                Name = x.Name,
                Status = x.Status
            });
            return Ok(schools);
        }

        //Search
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool(int id)
        {
            var school = await _iSchoolRepository.GetById(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(new SchoolViewModel()
            {
                Id = school.SchoolId,
                Name = school.Name,
                Status = school.Status
            });
        }
     
        //AddSchool
         [HttpPost]
        public async Task<IActionResult> PostSchool(SchoolViewModel schoolViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schools = await _iSchoolRepository.Create(new School()
            {
                SchoolId = schoolViewModel.Id,
                Name = schoolViewModel.Name,
                Status = schoolViewModel.Status
            });


            return CreatedAtAction("GetSchool", new { id = schools.SchoolId }, schools);
        }

        //Edit School
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(int id, SchoolViewModel schoolViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schoolForm = await _iSchoolRepository.GetById(id);
            if (schoolForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            schoolForm.Name = schoolViewModel.Name;
            schoolForm.Status = schoolViewModel.Status;
            var schools = await _iSchoolRepository.Update(schoolForm);

            return Ok(new SchoolViewModel()
            {
                Id = schools.SchoolId,
                Name = schools.Name,
                Status = schools.Status
            });
        }

        // DELETE School
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var school = await _iSchoolRepository.GetById(id);
            if (school == null)
            {
                return NotFound();
            }
            return Ok(await _iSchoolRepository.Delete(school));
        }

    }
}
