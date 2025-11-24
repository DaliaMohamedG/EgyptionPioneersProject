using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Configurations
{
    public class Treatment_ProductConfiguration : IEntityTypeConfiguration<Treatment_Product>
    {
        public void Configure(EntityTypeBuilder<Treatment_Product> builder)
        {
            builder.HasKey(tp => new { tp.T_Id, tp.Pr_Id });

            builder.HasOne(tp => tp.Treatment)
                .WithMany(t => t.TreatmentProducts)
                .HasForeignKey(tp => tp.T_Id);


            builder.HasOne(tp => tp.Product)
                .WithMany(p => p.TreatmentProducts)
                .HasForeignKey(tp => tp.Pr_Id);
        }
    }
}
