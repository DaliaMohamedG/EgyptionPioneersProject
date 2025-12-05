using EgyptionPioneersProject.Data;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task DeleteAsync(Order old);
        Task<List<Order>> GetByPatientIdAsync(int patientId);
        Task UpdateAsync(Order old);
    }

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Order old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetByPatientIdAsync(int patientId)
            => await _context.Orders
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .Where(o => o.P_Id == patientId)
        .OrderByDescending(o => o.O_Date)
        .ToListAsync();

        public async Task UpdateAsync(Order old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
