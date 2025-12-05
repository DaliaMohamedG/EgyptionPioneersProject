using System.Diagnostics;
using System.Security.Claims;
using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Utils;
using Microsoft.AspNetCore.Authentication;
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
        private readonly IAppointmentService _appointmentService;
        private readonly AppDbContext _context;
        public PagesController(IPatientService patientService, AppDbContext context, IOrderService orderService, IProductService productService, IAppointmentService appointmentService )
        {
            _patientService = patientService;
            _context = context;
            _orderService = orderService;
            _productService = productService;
            _appointmentService= appointmentService;
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
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, patient.P_Id.ToString()),
            new Claim(ClaimTypes.Name, patient.P_Email)
        };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal);

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

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(int[] selectedProducts)
        {
            if (selectedProducts == null || selectedProducts.Length == 0)
            {
                TempData["Error"] = "Please select at least one product.";
                return RedirectToAction("PlaceOrder");
            }

            // جلب الـ Patient ID من الـ Claims
            var patientId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var patient = await _patientService.GetByIdAsync(patientId);

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
                    order.OrderProducts.Add(new Order_Product
                    {
                        Pr_Id = product.Pr_Id
                    });

                    totalAmount += product.Pr_Price;
                }
            }

            order.O_Total_Amount = totalAmount;

            await _orderService.CreateAsync(order);

            TempData["Success"] = "Order placed successfully!";
            return RedirectToAction("MyOrders", "Pages");
        }
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            // 1. نجيب الإيميل من الـ Login
            var email = User.Identity.Name;

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login");
            }

            // 2. نجيب المريض
            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null)
            {
                return RedirectToAction("Login");
            }

            // 3. نجيب الأوردرز بتاعته مع الـ OrderProducts والـ Products
            var orders = await _context.Orders
                .Where(o => o.P_Id == patient.P_Id)
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .ToListAsync();

            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> BookAppointment()
        {
            // نجيب قائمة الدكاترة للـ dropdown
            var doctors = await _context.Doctors.ToListAsync();
            ViewBag.Doctors = doctors;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment(int doctorId, DateTime date, TimeSpan time)
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null)
                return RedirectToAction("Login");

            var appointment = new Appointment
            {
                D_Id = doctorId,
                P_Id = patient.P_Id,
                A_Date = date,
                A_Time = time,
                A_Status = "Pending"
            };

            var result = await _appointmentService.CreateAsync(appointment);
            if (result == null)
            {
                TempData["Error"] = "Doctor already booked at this time. Please choose another slot.";
                return RedirectToAction("BookAppointment", "Pages");
            }

            TempData["Success"] = "Appointment booked successfully!";
            return RedirectToAction("MyAppointments", "Pages");
        }

        [HttpGet]
        public async Task<IActionResult> MyAppointments()
        {
            var email = User.Identity.Name;
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null)
                return RedirectToAction("Login");

            var appointments = await _context.Appointments
                .Where(a => a.P_Id == patient.P_Id)
                .Include(a => a.Doctor)
                .ToListAsync();

            return View(appointments);
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
