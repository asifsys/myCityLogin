using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCityLogin.HospitalService.API.DTOs;
using myCityLogin.HospitalService.API.Interfaces;
using myCityLogin.HospitalService.API.Models;
using myCityLogin.HospitalService.API.Repository;

namespace myCityLogin.HospitalService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _repository;

        public HospitalController(IHospitalRepository repository)
        {
            _repository = repository;
        }

        // GET api/hospital
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hospitals = await _repository.GetAll();
            return Ok(hospitals.Select(MapToResponse));
        }

        [HttpGet("SearchAll")]
        public async Task<IActionResult> SearchAll([FromQuery] string? location, [FromQuery] string? category, int page = 1, int pageSize = 10)
        {
            var result = await _repository.SearchAll(location,category, page, pageSize);

            return Ok(result);
        }

        // GET api/hospital/search?location=dhanbad&keyword=cardiac
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] string? location, [FromQuery] string? category)
        {
            var hospitals = await _repository.Search(location, category);
            return Ok(hospitals.Select(MapToResponse));
        }

        // GET api/hospital/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hospital = await _repository.GetById(id);

            if (hospital == null)
                return NotFound(new { message = "Hospital not found" });

            return Ok(MapToResponse(hospital));
        }

        // POST api/hospital
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] HospitalDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hospital = new Hospital
            {
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Specialization = dto.Specialization
            };

            var created = await _repository.Create(hospital);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                MapToResponse(created));
        }

        // PUT api/hospital/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] HospitalUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hospital = new Hospital
            {
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                Specialization = dto.Specialization,
                IsActive = dto.IsActive
            };

            var updated = await _repository.Update(id, hospital);

            if (updated == null)
                return NotFound(new { message = "Hospital not found" });

            return Ok(MapToResponse(updated));
        }

        // DELETE api/hospital/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);

            if (!deleted)
                return NotFound(new { message = "Hospital not found" });

            return Ok(new { message = "Hospital deleted successfully" });
        }

        private static HospitalResponseDto MapToResponse(Hospital h) => new()
        {
            Id = h.Id,
            Name = h.Name,
            Location = h.Location,
            Address = h.Address,
            Phone = h.Phone,
            Email = h.Email,
            Specialization = h.Specialization,
            IsActive = h.IsActive,
            CreatedAt = h.CreatedAt
        };
    }
}
