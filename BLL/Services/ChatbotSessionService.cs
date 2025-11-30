using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IChatbotSessionService
    {
        Task<IEnumerable<ChatbotSession>> GetAllAsync();
        Task<ChatbotSession?> GetByIdAsync(int id);
        Task<ChatbotSession> CreateAsync(ChatbotSession cs);
        Task<ChatbotSession?> UpdateAsync(int id, ChatbotSession cs);
        Task<bool> DeleteAsync(int id);
    }
    public class ChatbotSessionService : IChatbotSessionService
    {
        private readonly IChatbotSessionRepository _repo;

        public ChatbotSessionService(IChatbotSessionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ChatbotSession>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<ChatbotSession?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<ChatbotSession> CreateAsync(ChatbotSession cs)
        {
            cs.Cs_Date = DateTime.Now;
            await _repo.AddAsync(cs);
            return cs;
        }

        public async Task<ChatbotSession?> UpdateAsync(int id, ChatbotSession cs)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.Cs_Result = cs.Cs_Result;
            old.P_Id = cs.P_Id;
            old.Dis_Id = cs.Dis_Id;

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
