using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IDiseaseTreatmentRepository : IRepository<Disease_Treatment>
    {
        Task<List<Treatment>> GetTreatmentsByDiseaseIdAsync(int diseaseId);
    }

    public class DiseaseTreatmentRepository : Repository<Disease_Treatment>, IDiseaseTreatmentRepository
    {
        private readonly AppDbContext _context;
        public DiseaseTreatmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Treatment>> GetTreatmentsByDiseaseIdAsync(int diseaseId)
        {
            return await _context.Treatments
                .Where(t => _context.Disease_Treatments.Any(dt => dt.Dis_Id == diseaseId && dt.T_Id == t.T_Id))
                .ToListAsync();
        }
    }

}
