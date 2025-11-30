using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface ISymptomRepository
    {
        Task<IEnumerable<Symptom>> GetAllAsync();
        Task<Symptom?> GetByIdAsync(int id);
        Task AddAsync(Symptom symptom);
        Task UpdateAsync(Symptom symptom);
        Task DeleteAsync(Symptom symptom);
    }

    public class SymptomRepository : ISymptomRepository
    {
        private readonly AppDbContext _context;
        public SymptomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Symptom>> GetAllAsync() =>
            await _context.Symptoms.ToListAsync();

        public async Task<Symptom?> GetByIdAsync(int id) =>
            await _context.Symptoms
                          .Include(s => s.DiseaseSymptoms)
                          .FirstOrDefaultAsync(s => s.S_Id == id);

        public async Task AddAsync(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Symptom symptom)
        {
            _context.Symptoms.Update(symptom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Symptom symptom)
        {
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
        }
    }
}
