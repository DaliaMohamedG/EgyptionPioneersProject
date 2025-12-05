using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace EgyptionPioneersProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Authentication
            builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Pages/Login";
                });

            // Authorization
            builder.Services.AddAuthorization();

            // MVC
            builder.Services.AddControllersWithViews();

            // DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("EgyptionPioneersProject")
                )
            );

            // Repositories
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IChatbotSessionRepository, ChatbotSessionRepository>();
            builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            builder.Services.AddScoped<ISymptomRepository, SymptomRepository>();
            builder.Services.AddScoped<IDiseaseSymptomRepository, DiseaseSymptomRepository>();
            builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            builder.Services.AddScoped<IDiseaseTreatmentRepository, DiseaseTreatmentRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ITreatmentProductRepository, TreatmentProductRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
            builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();

            // Services
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IChatbotSessionService, ChatbotSessionService>();
            builder.Services.AddScoped<IDiseaseService, DiseaseService>();
            builder.Services.AddScoped<ISymptomService, SymptomService>();
            builder.Services.AddScoped<ITreatmentService, TreatmentService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();

            // Session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(8);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();   // لازم قبل Authorization
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pages}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
