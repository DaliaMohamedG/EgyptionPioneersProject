using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var order = await _service.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        //[HttpGet("patient/{patientId}")]
        //public async Task<ActionResult<IEnumerable<Order>>> GetByPatientId(int patientId)
        //{
        //    var orders = await _service.GetByPatientIdAsync(patientId);
        //    if (!orders.Any()) return NotFound();
        //    return Ok(orders);
        //}

        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order o)
        {
            var created = await _service.CreateAsync(o);
            return CreatedAtAction(nameof(GetById), new { id = created.O_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Update(int id, Order o)
        {
            var updated = await _service.UpdateAsync(id, o);
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
