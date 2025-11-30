using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface ITreatmentService
    {
        Task<IEnumerable<Treatment>> GetAllAsync();
        Task<Treatment?> GetByIdAsync(int id);
        Task<Treatment> CreateAsync(Treatment t);
        Task<Treatment?> UpdateAsync(int id, Treatment t);
        Task<bool> DeleteAsync(int id);
    }

    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _repo;

        public TreatmentService(ITreatmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Treatment>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Treatment?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Treatment> CreateAsync(Treatment t)
        {
            await _repo.AddAsync(t);
            return t;
        }

        public async Task<Treatment?> UpdateAsync(int id, Treatment t)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.T_Name = t.T_Name;
            old.T_Description = t.T_Description;
            old.T_Instruction = t.T_Instruction;
            old.T_Duration = t.T_Duration;

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
