using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient?> GetByEmailAsync(string email);
        Task<Patient> CreateAsync(Patient patient);
        Task<Patient?> UpdateAsync(int id, Patient patient);
        Task<bool> DeleteAsync(int id);
    }
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _patientRepository.GetByEmailAsync(email);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            return patient;
        }

        public async Task<Patient?> UpdateAsync(int id, Patient patient)
        {
            var existing = await _patientRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            existing.P_Name = patient.P_Name;
            existing.P_Email = patient.P_Email;
            existing.P_Pass = patient.P_Pass;
            existing.P_Gender = patient.P_Gender;
            existing.P_Age = patient.P_Age;
            existing.Skin_Type = patient.Skin_Type;
            existing.Medical_History = patient.Medical_History;

            await _patientRepository.UpdateAsync(existing);

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
                return false;

            await _patientRepository.DeleteAsync(patient);

            return true;
        }
    }
}
