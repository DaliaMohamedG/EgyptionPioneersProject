using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product p)
        {
            var created = await _service.CreateAsync(p);
            return CreatedAtAction(nameof(GetById), new { id = created.Pr_Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product p)
        {
            var updated = await _service.UpdateAsync(id, p);
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
