using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task DeleteAsync(Patient patient);
        Task<Patient?> GetByEmailAsync(string email);
        Task UpdateAsync(Patient existing);
    }

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Patient patient)
        {
            _dbSet.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.P_Email == email);
        }

        public async Task UpdateAsync(Patient existing)
        {
            _dbSet.Update(existing);
            await _context.SaveChangesAsync();
        }
    }
}
