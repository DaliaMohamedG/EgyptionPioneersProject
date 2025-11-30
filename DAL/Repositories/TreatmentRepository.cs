using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;

namespace EgyptionPioneersProject.Repositories
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        Task DeleteAsync(Treatment old);
        Task UpdateAsync(Treatment old);
    }

    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Treatment old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Treatment old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
