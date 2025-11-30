using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task DeleteAsync(Doctor old);
        Task<List<Doctor>> GetBySpecializationAsync(string specialization);
        Task UpdateAsync(Doctor old);
    }

    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Doctor old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetBySpecializationAsync(string specialization)
        {
            return await _dbSet
                .Where(d => d.D_Specialization == specialization)
                .ToListAsync();
        }

        public async Task UpdateAsync(Doctor old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
