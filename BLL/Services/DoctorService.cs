using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<Doctor?> UpdateAsync(int id, Doctor doctor);
        Task<bool> DeleteAsync(int id);
    }
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Doctor?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            await _repo.AddAsync(doctor);
            return doctor;
        }

        public async Task<Doctor?> UpdateAsync(int id, Doctor doctor)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.D_Name = doctor.D_Name;
            old.D_Email = doctor.D_Email;
            old.D_Pass = doctor.D_Pass;
            old.D_Specialization = doctor.D_Specialization;
            old.D_Experience = doctor.D_Experience;
            old.D_Working_Hour = doctor.D_Working_Hour;

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
