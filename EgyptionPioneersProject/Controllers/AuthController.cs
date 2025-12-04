using Microsoft.AspNetCore.Mvc;
using Services.Services;
using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Utils;

namespace EgyptionPioneersProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AuthController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        // GET: /Auth/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string userType, Patient patientModel, Doctor doctorModel)
        {
            // userType = "Patient" or "Doctor"
            if (userType == "Doctor")
            {
                // basic validation
                if (string.IsNullOrWhiteSpace(doctorModel.D_Email) ||
                    string.IsNullOrWhiteSpace(doctorModel.D_Pass) ||
                    string.IsNullOrWhiteSpace(doctorModel.D_Name))
                {
                    ModelState.AddModelError("", "Please fill required doctor fields.");
                    return View();
                }

                // check unique email
                var existingDoc = await _doctorService.GetByEmailAsync(doctorModel.D_Email);
                if (existingDoc != null)
                {
                    ModelState.AddModelError("D_Email", "Email already registered.");
                    return View();
                }

                // hash password
                doctorModel.D_Pass = HashHelper.Hash(doctorModel.D_Pass);

                await _doctorService.CreateAsync(doctorModel);

                // set session
                HttpContext.Session.SetInt32("UserId", doctorModel.D_Id);
                HttpContext.Session.SetString("UserType", "Doctor");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Patient flow
                if (string.IsNullOrWhiteSpace(patientModel.P_Email) ||
                    string.IsNullOrWhiteSpace(patientModel.P_Pass) ||
                    string.IsNullOrWhiteSpace(patientModel.P_Name))
                {
                    ModelState.AddModelError("", "Please fill required patient fields.");
                    return View();
                }

                // check unique email
                var existing = await _patientService.GetByEmailAsync(patientModel.P_Email);
                if (existing != null)
                {
                    ModelState.AddModelError("P_Email", "Email already registered.");
                    return View();
                }

                // hash password
                patientModel.P_Pass = HashHelper.Hash(patientModel.P_Pass);

                await _patientService.CreateAsync(patientModel);

                HttpContext.Session.SetInt32("UserId", patientModel.P_Id);
                HttpContext.Session.SetString("UserType", "Patient");

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userType, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Please provide email and password.");
                return View();
            }

            var hashed = HashHelper.Hash(password);

            if (userType == "Doctor")
            {
                var doctor = await _doctorService.GetByEmailAsync(email);
                if (doctor == null || doctor.D_Pass != hashed)
                {
                    ModelState.AddModelError("", "Invalid credentials.");
                    return View();
                }

                HttpContext.Session.SetInt32("UserId", doctor.D_Id);
                HttpContext.Session.SetString("UserType", "Doctor");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var patient = await _patientService.GetByEmailAsync(email);
                if (patient == null || patient.P_Pass != hashed)
                {
                    ModelState.AddModelError("", "Invalid credentials.");
                    return View();
                }

                HttpContext.Session.SetInt32("UserId", patient.P_Id);
                HttpContext.Session.SetString("UserType", "Patient");
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: /Auth/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("UserType");
            return RedirectToAction("Login");
        }
    }
}