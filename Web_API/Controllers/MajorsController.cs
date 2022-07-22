using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.MajorDto;
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
            var major = await _majorsRepository.GetList();
            var majors = major.Select(x => new MajorViewModel()
            {
                Id = x.MajorId,
                Name = x.Name,
                Status = x.Status,
                SchoolId = x.SchoolId
            });
            return Ok(majors);
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

            return Ok(new MajorViewModel()
            {
                Id = majors.MajorId,
                Name = majors.Name,
                Status = majors.Status,
                SchoolId = majors.SchoolId
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajors(int id, MajorViewModel majorViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var majorForm = await _majorsRepository.GetById(id);
            if (majorForm == null)
            {
                return NotFound($"{id} is not fond");
            }

            majorForm.Name = majorViewModel.Name;
            majorForm.Status = majorViewModel.Status;
            majorForm.SchoolId = majorViewModel.SchoolId;
            var major = await _majorsRepository.Update(majorForm);
            return Ok(new MajorViewModel()
            {
                Id = major.MajorId,
                Name = major.Name,
                Status = major.Status,
                SchoolId = major.SchoolId
            });

        }

        // POST: api/Majors
        [HttpPost]
        public async Task<IActionResult> PostMajors(MajorViewModel majorViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var major = await _majorsRepository.Create(new Majors()
            {
                MajorId = majorViewModel.Id,
                Name = majorViewModel.Name,
                Status = majorViewModel.Status,
                SchoolId = majorViewModel.SchoolId
            });

            return CreatedAtAction("GetMajors", new { id = major.MajorId }, major);
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
