using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification?> GetByIdAsync(int id);
        Task<Notification> CreateAsync(Notification n);
        Task<Notification?> UpdateAsync(int id, Notification n);
        Task<bool> DeleteAsync(int id);
    }
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;

        public NotificationService(INotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Notification?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Notification> CreateAsync(Notification n)
        {
            await _repo.AddAsync(n);
            return n;
        }

        public async Task<Notification?> UpdateAsync(int id, Notification n)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.N_Type = n.N_Type;
            old.N_Date = n.N_Date;
            old.N_Message = n.N_Message;
            old.P_Id = n.P_Id;
            old.D_Id = n.D_Id;

            await _repo.UpdateAsync(old);
            return old;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return false;

            await _repo.DeleteAsync(old);
            return true;
        }
    }

}
