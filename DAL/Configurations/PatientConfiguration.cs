using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.P_Id);

            builder.Property(p => p.P_Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.P_Email).IsRequired().HasMaxLength(150);
            builder.Property(p => p.P_Pass).IsRequired();
            builder.Property(p => p.P_Gender).HasMaxLength(10);

            builder.Property(p => p.Skin_Type).HasMaxLength(50);

            builder.HasMany(p => p.Appointments)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.P_Id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


