using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class SymptomConfiguration : IEntityTypeConfiguration<Symptom>
    {
        public void Configure(EntityTypeBuilder<Symptom> builder)
        {
            builder.HasKey(s => s.S_Id);

            builder.Property(s => s.S_Description).IsRequired();
        }
    }
}
