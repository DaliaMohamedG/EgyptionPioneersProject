using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EgyptionPioneersProject.Configurations
{
    public class ChatbotSessionConfiguration : IEntityTypeConfiguration<ChatbotSession>
    {
        public void Configure(EntityTypeBuilder<ChatbotSession> builder)
        {
            builder.HasKey(c => c.Cs_Id);

            builder.Property(c => c.Cs_Date).IsRequired();

            builder.HasOne(c => c.Patient)
                .WithMany(p => p.ChatbotSessions)
                .HasForeignKey(c => c.P_Id);

            builder.HasOne(c => c.Disease)
                .WithMany(d => d.ChatbotSessions)
                .HasForeignKey(c => c.Dis_Id);
        }
    }
}
