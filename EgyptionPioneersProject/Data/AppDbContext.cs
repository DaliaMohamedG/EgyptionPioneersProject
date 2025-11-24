using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
namespace EgyptionPioneersProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        // DbSets
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ChatbotSession> ChatbotSessions { get; set; }
        public DbSet<Disease_Symptom> Disease_Symptoms { get; set; }
        public DbSet<Disease_Treatment> Disease_Treatments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Treatment_Product> Treatment_Products { get; set; }

    }
}
