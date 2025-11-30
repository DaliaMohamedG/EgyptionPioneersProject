using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotSessionController : ControllerBase
    {
        private readonly IChatbotSessionService _service;

        public ChatbotSessionController(IChatbotSessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatbotSession>>> GetAll()
        {
            var sessions = await _service.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatbotSession>> GetById(int id)
        {
            var session = await _service.GetByIdAsync(id);
            if (session == null) return NotFound();
            return Ok(session);
        }

        //[HttpGet("patient/{patientId}")]
        //public async Task<ActionResult<IEnumerable<ChatbotSession>>> GetByPatient(int patientId)
        //{
        //    var sessions = await _service.GetByPatientIdAsync(patientId);
        //    return Ok(sessions);
        //}

        [HttpPost]
        public async Task<ActionResult<ChatbotSession>> Create(ChatbotSession s)
        {
            var created = await _service.CreateAsync(s);
            return CreatedAtAction(nameof(GetById), new { id = created.Cs_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatbotSession>> Update(int id, ChatbotSession s)
        {
            var updated = await _service.UpdateAsync(id, s);
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
