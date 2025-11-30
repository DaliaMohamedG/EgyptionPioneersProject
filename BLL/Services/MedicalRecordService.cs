using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetAllAsync();
        Task<MedicalRecord?> GetByIdAsync(int id);
        Task<MedicalRecord> CreateAsync(MedicalRecord m);
        Task<MedicalRecord?> UpdateAsync(int id, MedicalRecord m);
        Task<bool> DeleteAsync(int id);
    }
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repo;

        public MedicalRecordService(IMedicalRecordRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<MedicalRecord?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<MedicalRecord> CreateAsync(MedicalRecord m)
        {
            await _repo.AddAsync(m);
            return m;
        }

        public async Task<MedicalRecord?> UpdateAsync(int id, MedicalRecord m)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.Md_Notes = m.Md_Notes;
            old.Md_Source = m.Md_Source;
            old.Md_Diagnoses = m.Md_Diagnoses;
            old.P_Id = m.P_Id;
            old.D_Id = m.D_Id;
            old.Dis_Id = m.Dis_Id;

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
