using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IPatientService _patientService;

        public OrderController(IOrderService orderService, IProductService productService, IPatientService patientService)
        {
            _orderService = orderService;
            _productService = productService;
            _patientService = patientService;
        }



        // GET: MyOrders
        public async Task<IActionResult> MyOrders()
        {
            var email = User.Identity.Name;
            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null) return NotFound();

            var orders = await _orderService.GetByPatientIdAsync(patient.P_Id);
            return View(orders);
        }
    }
}
