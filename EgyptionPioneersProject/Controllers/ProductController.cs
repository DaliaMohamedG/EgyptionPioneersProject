using EgyptionPioneersProject.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // LIST
        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            return View(products);
        }

        // DETAILS
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        // CREATE GET
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
                return View(p);

            // لو مفيش صورة داخلة
            if (imageFile == null || imageFile.Length == 0)
            {
                p.Pr_Image = "/images/Dermacare.jpg";
            }
            else
            {
                // لو الصورة داخلة → ارفعها
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                p.Pr_Image = "/images/" + fileName;
            }

            await _service.CreateAsync(p);
            return RedirectToAction(nameof(Index));
        }


        // EDIT GET
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        // EDIT POST
        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Product p)
        {
            if (ModelState.IsValid)
                return View(p);

            await _service.UpdateAsync(id, p);
            return RedirectToAction(nameof(Index));
        }

        // DELETE GET
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound();
            return View(p);
        }

        // DELETE POST
        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
