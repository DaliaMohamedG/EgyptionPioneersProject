using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class Disease_SymptomConfiguration : IEntityTypeConfiguration<Disease_Symptom>
    {
        public void Configure(EntityTypeBuilder<Disease_Symptom> builder)
        {
            builder.HasKey(ds => new { ds.Dis_Id, ds.S_Id });

            builder.HasOne(ds => ds.Disease)
                .WithMany(d => d.DiseaseSymptoms)
                .HasForeignKey(ds => ds.Dis_Id);

            builder.HasOne(ds => ds.Symptom)
                .WithMany(s => s.DiseaseSymptoms)
                .HasForeignKey(ds => ds.S_Id);
        }
    }
}
