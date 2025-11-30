using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task DeleteAsync(Notification old);
        Task<List<Notification>> GetByPatientIdAsync(int patientId);
        Task UpdateAsync(Notification old);
    }

    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context) { }

        public async Task<List<Notification>> GetByPatientIdAsync(int patientId)
            => await _dbSet.Where(n => n.P_Id == patientId).ToListAsync();

        public async Task DeleteAsync(Notification old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }

    }

}
