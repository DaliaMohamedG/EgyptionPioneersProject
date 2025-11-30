using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
        Task DeleteAsync(MedicalRecord old);
        Task<List<MedicalRecord>> GetByPatientIdAsync(int patientId);
        Task UpdateAsync(MedicalRecord old);
    }

    public class MedicalRecordRepository : Repository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(MedicalRecord old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MedicalRecord>> GetByPatientIdAsync(int patientId)
            => await _dbSet
                .Where(m => m.P_Id == patientId)
                .ToListAsync();

        public async Task UpdateAsync(MedicalRecord old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
