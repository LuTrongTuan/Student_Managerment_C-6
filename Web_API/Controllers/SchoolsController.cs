using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web_API.Data;
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

        // GET: api/Schools
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var school = await _iSchoolRepository.GetList();
            return Ok(school);
        }

        // GET: api/Schools/5
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
        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

         [HttpPost("AddSchool")]
        public async Task<IActionResult> PostSchool(School school)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schools = await _iSchoolRepository.Create(school);

            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, schools);
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
            var schools = await _iSchoolRepository.Update(school);

            return Ok(schools);
        }

        // DELETE: api/Schools/5
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
