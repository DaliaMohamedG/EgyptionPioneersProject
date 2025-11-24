using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.HasKey(d => d.Dis_Id);

            builder.Property(d => d.Dis_Name).HasMaxLength(150).IsRequired();
            builder.Property(d => d.Dis_Severity_Level).HasMaxLength(50);
        }
    }
}
