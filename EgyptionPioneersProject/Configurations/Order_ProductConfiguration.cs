using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class Order_ProductConfiguration : IEntityTypeConfiguration<Order_Product>
    {
        public void Configure(EntityTypeBuilder<Order_Product> builder)
        {
            builder.HasKey(op => new { op.O_Id, op.Pr_Id });

            builder.HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.O_Id);

            builder.HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.Pr_Id);
        }
    }
}
