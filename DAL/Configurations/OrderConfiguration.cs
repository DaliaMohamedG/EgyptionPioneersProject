using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.O_Id);

            builder.Property(o => o.O_Status).HasMaxLength(50);

            builder.HasOne(o => o.Patient)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.P_Id);
        }
    }
}
