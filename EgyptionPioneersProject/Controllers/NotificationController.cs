using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAll()
        {
            var notifications = await _service.GetAllAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetById(int id)
        {
            var notification = await _service.GetByIdAsync(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        //[HttpGet("patient/{patientId}")]
        //public async Task<ActionResult<IEnumerable<Notification>>> GetByPatientId(int patientId)
        //{
        //    var notifications = await _service.GetByPatientIdAsync(patientId);
        //    if (!notifications.Any()) return NotFound();
        //    return Ok(notifications);
        //}

        [HttpPost]
        public async Task<ActionResult<Notification>> Create(Notification n)
        {
            var created = await _service.CreateAsync(n);
            return CreatedAtAction(nameof(GetById), new { id = created.N_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Notification>> Update(int id, Notification n)
        {
            var updated = await _service.UpdateAsync(id, n);
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
