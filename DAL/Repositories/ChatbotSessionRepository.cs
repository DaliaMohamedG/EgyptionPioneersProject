using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IChatbotSessionRepository : IRepository<ChatbotSession>
    {
        Task DeleteAsync(ChatbotSession old);
        Task<List<ChatbotSession>> GetByPatientIdAsync(int patientId);
        Task UpdateAsync(ChatbotSession old);
    }

    public class ChatbotSessionRepository : Repository<ChatbotSession>, IChatbotSessionRepository
    {
        public ChatbotSessionRepository(AppDbContext context) : base(context) { }

        public async Task<List<ChatbotSession>> GetByPatientIdAsync(int patientId)
            => await _dbSet.Where(c => c.P_Id == patientId).ToListAsync();
        public async Task DeleteAsync(ChatbotSession old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ChatbotSession old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }


    }

}
