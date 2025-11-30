using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        Task DeleteAsync(Disease old);
        Task<Disease?> GetByNameAsync(string name);
        Task UpdateAsync(Disease old);
    }

    public class DiseaseRepository : Repository<Disease>, IDiseaseRepository
    {
        public DiseaseRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Disease old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task<Disease?> GetByNameAsync(string name)
            => await _dbSet.FirstOrDefaultAsync(d => d.Dis_Name == name);

        public async Task UpdateAsync(Disease old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
