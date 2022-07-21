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
    public class MajorsController : ControllerBase
    {
        private readonly IMajorsRepository _majorsRepository;

        public MajorsController(IMajorsRepository majorsRepository)
        {
            _majorsRepository = majorsRepository;
        }

        // GET: api/Majors
        [HttpGet]
        public async Task<IActionResult> GetMajors()
        {
            return Ok(await _majorsRepository.GetList());
        }

        // GET: api/Majors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Majors>> GetMajors(int id)
        {
            var majors = await _majorsRepository.GetById(id);

            if (majors == null)
            {
                return NotFound();
            }

            return Ok(majors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajors(int id, Majors majors)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var majorForm = await _majorsRepository.GetById(id);
            if (majorForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            majorForm.Name = majors.Name;
            majorForm.Status = majors.Status;
            majorForm.SchoolId = majors.SchoolId;
            var major = await _majorsRepository.Update(majorForm);
            return Ok(major);
        }

        // POST: api/Majors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMajors(Majors majors)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var major = _majorsRepository.Create(majors);

            return CreatedAtAction("GetMajors", new { id = majors.MajorId }, major);
        }

        // DELETE: api/Majors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajors(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var majorForm = await _majorsRepository.GetById(id);
            if (majorForm == null)
            {
                return NotFound($"{id} is not fond");
            }
            return Ok(await _majorsRepository.Delete(majorForm));
        }
    }
}
