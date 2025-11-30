using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IDiseaseService
    {
        Task<IEnumerable<Disease>> GetAllAsync();
        Task<Disease?> GetByIdAsync(int id);
        Task<Disease> CreateAsync(Disease disease);
        Task<Disease?> UpdateAsync(int id, Disease disease);
        Task<bool> DeleteAsync(int id);
    }

    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _repo;

        public DiseaseService(IDiseaseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Disease>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Disease?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Disease> CreateAsync(Disease disease)
        {
            await _repo.AddAsync(disease);
            return disease;
        }

        public async Task<Disease?> UpdateAsync(int id, Disease disease)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.Dis_Name = disease.Dis_Name;
            old.Dis_Description = disease.Dis_Description;
            old.Dis_Severity_Level = disease.Dis_Severity_Level;

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
