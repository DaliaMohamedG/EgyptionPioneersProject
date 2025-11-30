using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> GetByPatientIdAsync(int patientId);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task UpdateAsync(Appointment old);
        Task DeleteAsync(Appointment old);

        // صححنا: FindAsync تاخد Expression<Func<Appointment, bool>>
        Task<List<Appointment>> FindAsync(System.Linq.Expressions.Expression<Func<Appointment, bool>> predicate);
    }

    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context) { }

        public async Task<List<Appointment>> GetByPatientIdAsync(int patientId)
            => await _dbSet.Where(a => a.P_Id == patientId).ToListAsync();

        public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId)
            => await _dbSet.Where(a => a.D_Id == doctorId).ToListAsync();

        public async Task UpdateAsync(Appointment old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Appointment old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> FindAsync(System.Linq.Expressions.Expression<Func<Appointment, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
