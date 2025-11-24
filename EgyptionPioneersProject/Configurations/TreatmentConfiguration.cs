using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(t => t.T_Id);
            builder.Property(t => t.T_Name).HasMaxLength(150).IsRequired();
        }
    }
}
