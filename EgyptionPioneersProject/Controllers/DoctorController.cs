using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAll()
        {
            var doctors = await _service.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetById(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        //[HttpGet("specialization/{spec}")]
        //public async Task<ActionResult<IEnumerable<Doctor>>> GetBySpecialization(string spec)
        //{
        //    var doctors = await _service.GetBySpecializationAsync(spec);
        //    return Ok(doctors);
        //}

        [HttpPost]
        public async Task<ActionResult<Doctor>> Create(Doctor d)
        {
            var created = await _service.CreateAsync(d);
            if (created == null) return BadRequest("Doctor already exists.");
            return CreatedAtAction(nameof(GetById), new { id = created.D_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> Update(int id, Doctor d)
        {
            var updated = await _service.UpdateAsync(id, d);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
