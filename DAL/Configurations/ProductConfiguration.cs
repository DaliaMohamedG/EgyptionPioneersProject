using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Pr_Id);

            builder.Property(p => p.Pr_Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Pr_Category).HasMaxLength(100);
        }
    }
}
