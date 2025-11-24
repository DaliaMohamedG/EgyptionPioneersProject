using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class Disease_TreatmentConfiguration : IEntityTypeConfiguration<Disease_Treatment>
    {
        public void Configure(EntityTypeBuilder<Disease_Treatment> builder)
        {
            builder.HasKey(dt => new { dt.Dis_Id, dt.T_Id });

            builder.HasOne(dt => dt.Disease)
                .WithMany(d => d.DiseaseTreatments)
                .HasForeignKey(dt => dt.Dis_Id);

            builder.HasOne(dt => dt.Treatment)
                .WithMany(t => t.DiseaseTreatments)
                .HasForeignKey(dt => dt.T_Id);
        }
    }
}
