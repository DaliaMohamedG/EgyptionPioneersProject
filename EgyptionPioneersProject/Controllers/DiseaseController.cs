using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _service;

        public DiseaseController(IDiseaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetAll()
        {
            var diseases = await _service.GetAllAsync();
            return Ok(diseases);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetById(int id)
        {
            var disease = await _service.GetByIdAsync(id);
            if (disease == null) return NotFound();
            return Ok(disease);
        }

        //[HttpGet("name/{name}")]
        //public async Task<ActionResult<Disease>> GetByName(string name)
        //{
        //    var disease = await _service.GetByNameAsync(name);
        //    if (disease == null) return NotFound();
        //    return Ok(disease);
        //}

        [HttpPost]
        public async Task<ActionResult<Disease>> Create(Disease d)
        {
            var created = await _service.CreateAsync(d);
            if (created == null) return BadRequest("Disease already exists.");
            return CreatedAtAction(nameof(GetById), new { id = created.Dis_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Disease>> Update(int id, Disease d)
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
