using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{

    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _service;

        public TreatmentController(ITreatmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treatment>>> GetAll()
        {
            var treatments = await _service.GetAllAsync();
            return Ok(treatments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Treatment>> GetById(int id)
        {
            var treatment = await _service.GetByIdAsync(id);
            if (treatment == null) return NotFound();
            return Ok(treatment);
        }

        [HttpPost]
        public async Task<ActionResult<Treatment>> Create(Treatment t)
        {
            var created = await _service.CreateAsync(t);
            return CreatedAtAction(nameof(GetById), new { id = created.T_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Treatment>> Update(int id, Treatment t)
        {
            var updated = await _service.UpdateAsync(id, t);
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
