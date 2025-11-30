using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class SymptomController : Controller
    {
        private readonly ISymptomService _service;

        public SymptomController(ISymptomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Symptom>>> GetAll()
        {
            var symptoms = await _service.GetAllAsync();
            return Ok(symptoms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Symptom>> GetById(int id)
        {
            var symptom = await _service.GetByIdAsync(id);
            if (symptom == null) return NotFound();
            return Ok(symptom);
        }

        [HttpPost]
        public async Task<ActionResult<Symptom>> Create(Symptom s)
        {
            var created = await _service.CreateAsync(s);
            return CreatedAtAction(nameof(GetById), new { id = created.S_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Symptom>> Update(int id, Symptom s)
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
