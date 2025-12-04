using System.Diagnostics;
using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace EgyptionPioneersProject.Controllers
{
    public class PagesController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly AppDbContext _context;
        public PagesController(IPatientService patientService, AppDbContext context, IOrderService orderService, IProductService productService)
        {
            _patientService = patientService;
            _context = context;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var patient = await _patientService.GetByEmailAsync(email);
            if (patient != null && HashHelper.VerifyPassword(password, patient.P_Pass))
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Patient p)
        {
            p.P_Pass = HashHelper.Hash(p.P_Pass);

            var created = await _patientService.CreateAsync(p);
            if (created != null)
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Email already exists";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Products(string searchTerm)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Pr_Name.Contains(searchTerm));
            }

            return View(await products.ToListAsync());
        }
        public IActionResult SkinDiseases()
        {
            return View();
        }

        public IActionResult dailyskinroutine()
        {
            return View();
        }

        public IActionResult SkinTips()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PlaceOrder()
        {
            var products = await _productService.GetAllAsync();
            return View(products); // فحص الفيو متوقع List<Product>
        }

        // POST: PlaceOrder
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(int[] selectedProducts)
        {
            if (selectedProducts == null || selectedProducts.Length == 0)
            {
                TempData["Error"] = "Please select at least one product.";
                return RedirectToAction("PlaceOrder");
            }

            // جلب الـ Patient ID من الايميل الحالي
            var email = User.Identity.Name; // email المستخدم المسجل
            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null)
            {
                TempData["Error"] = "Patient not found.";
                return RedirectToAction("PlaceOrder");
            }

            var order = new Order
            {
                O_Date = DateTime.Now,
                O_Status = "Pending",
                P_Id = patient.P_Id,
                OrderProducts = new List<Order_Product>()
            };

            decimal totalAmount = 0;

            foreach (var prodId in selectedProducts)
            {
                var product = await _productService.GetByIdAsync(prodId);
                if (product != null)
                {
                    order.OrderProducts.Add(new Order_Product { Pr_Id = product.Pr_Id, Product = product });
                    totalAmount += product.Pr_Price;
                }
            }

            order.O_Total_Amount = totalAmount;
            await _orderService.CreateAsync(order);

            TempData["Success"] = "Order placed successfully!";
            return RedirectToAction("MyOrders");
        }


    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
