using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
        {
            var appointments = await _service.GetAllAsync();
            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(int id)
        {
            var appointment = await _service.GetByIdAsync(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> Create(Appointment a)
        {
            var created = await _service.CreateAsync(a);
            if (created == null)
                return BadRequest("Doctor already booked at this time.");
            return CreatedAtAction(nameof(GetById), new { id = created.Ap_Id }, created);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> Update(int id, Appointment a)
        {
            var updated = await _service.UpdateAsync(id, a);
            if (updated == null)
                return BadRequest("Conflict: Doctor already booked at this time or appointment not found.");
            return Ok(updated);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
