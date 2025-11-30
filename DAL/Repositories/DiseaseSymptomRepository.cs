using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IDiseaseSymptomRepository : IRepository<Disease_Symptom>
    {
        Task<List<Symptom>> GetSymptomsByDiseaseIdAsync(int diseaseId);
    }

    public class DiseaseSymptomRepository : Repository<Disease_Symptom>, IDiseaseSymptomRepository
    {
        private readonly AppDbContext _context;
        public DiseaseSymptomRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Symptom>> GetSymptomsByDiseaseIdAsync(int diseaseId)
        {
            return await _context.Symptoms
                .Where(s => _context.Disease_Symptoms.Any(ds => ds.Dis_Id == diseaseId && ds.S_Id == s.S_Id))
                .ToListAsync();
        }
    }

}
