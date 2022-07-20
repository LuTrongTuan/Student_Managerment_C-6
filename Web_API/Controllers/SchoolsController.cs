using System.Threading.Tasks;
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
         
            return Ok(await _iSchoolRepository.GetList());
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

            return Ok(school);
        }
     
        //AddSchool
         [HttpPost]
        public async Task<IActionResult> PostSchool([FromBody] School school)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schools = await _iSchoolRepository.Create(school);

            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, schools);
        }

        //Edit School
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schoolForm = await _iSchoolRepository.GetById(id);
            if (schoolForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            schoolForm.Name = school.Name;
            schoolForm.Status = school.Status;
            var schools = await _iSchoolRepository.Update(schoolForm);

            return Ok(schools);
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
