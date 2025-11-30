using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment?> CreateAsync(Appointment a);
        Task<Appointment?> UpdateAsync(int id, Appointment a);
        Task<bool> DeleteAsync(int id);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Appointment?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Appointment?> CreateAsync(Appointment a)
        {
            // Prevent duplicate booking
            var conflict = await _repo.FindAsync(x =>
                x.D_Id == a.D_Id &&
                x.A_Date == a.A_Date &&
                x.A_Time == a.A_Time
            );

            if (conflict.Any())
                return null; // doctor already booked

            await _repo.AddAsync(a);
            return a;
        }

        public async Task<Appointment?> UpdateAsync(int id, Appointment a)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            var conflict = await _repo.FindAsync(x =>
                x.D_Id == a.D_Id &&
                x.A_Date == a.A_Date &&
                x.A_Time == a.A_Time &&
                x.Ap_Id != id
            );

            if (conflict.Any())
                return null; // doctor already booked

            old.A_Date = a.A_Date;
            old.A_Time = a.A_Time;
            old.A_Status = a.A_Status;
            old.P_Id = a.P_Id;
            old.D_Id = a.D_Id;

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
