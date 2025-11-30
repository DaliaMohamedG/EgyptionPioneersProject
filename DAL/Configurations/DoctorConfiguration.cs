using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.D_Id);

            builder.Property(d => d.D_Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.D_Email).IsRequired().HasMaxLength(150);
            builder.Property(d => d.D_Pass).IsRequired();

            builder.Property(d => d.D_Specialization).HasMaxLength(150);
            builder.Property(d => d.D_Experience).HasMaxLength(100);
            builder.Property(d => d.D_Working_Hour).HasMaxLength(100);
        }
    }
}
