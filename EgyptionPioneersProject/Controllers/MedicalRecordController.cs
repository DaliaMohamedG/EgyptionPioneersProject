using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetAll()
        {
            var records = await _service.GetAllAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecord>> GetById(int id)
        {
            var record = await _service.GetByIdAsync(id);
            if (record == null) return NotFound();
            return Ok(record);
        }

        //[HttpGet("patient/{patientId}")]
        //public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetByPatientId(int patientId)
        //{
        //    var records = await _service.GetByPatientIdAsync(patientId);
        //    if (!records.Any()) return NotFound();
        //    return Ok(records);
        //}

        [HttpPost]
        public async Task<ActionResult<MedicalRecord>> Create(MedicalRecord r)
        {
            var created = await _service.CreateAsync(r);
            return CreatedAtAction(nameof(GetById), new { id = created.Md_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MedicalRecord>> Update(int id, MedicalRecord r)
        {
            var updated = await _service.UpdateAsync(id, r);
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
