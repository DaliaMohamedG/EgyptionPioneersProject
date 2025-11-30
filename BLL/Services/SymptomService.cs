using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface ISymptomService
    {
        Task<IEnumerable<Symptom>> GetAllAsync();
        Task<Symptom?> GetByIdAsync(int id);
        Task<Symptom> CreateAsync(Symptom symptom);
        Task<Symptom?> UpdateAsync(int id, Symptom symptom);
        Task<bool> DeleteAsync(int id);
    }

    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _repo;

        public SymptomService(ISymptomRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Symptom>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Symptom?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Symptom> CreateAsync(Symptom symptom)
        {
            await _repo.AddAsync(symptom);
            return symptom;
        }

        public async Task<Symptom?> UpdateAsync(int id, Symptom symptom)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.S_Description = symptom.S_Description;

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
