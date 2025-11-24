using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.N_Id);

            builder.Property(n => n.N_Type).HasMaxLength(50);

            builder.HasOne(n => n.Patient)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.P_Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(n => n.Doctor)
                .WithMany(d => d.Notifications)
                .HasForeignKey(n => n.D_Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
