using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(int id, Order order);
        Task<bool> DeleteAsync(int id);
        Task<List<Order>> GetByPatientIdAsync(int patientId);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Order> CreateAsync(Order order)
        {
            await _repo.AddAsync(order);
            return order;
        }

        public async Task<Order?> UpdateAsync(int id, Order order)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.O_Date = order.O_Date;
            old.O_Status = order.O_Status;
            old.O_Total_Amount = order.O_Total_Amount;
            old.P_Id = order.P_Id;

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

        public async Task<List<Order>> GetByPatientIdAsync(int patientId)
        {
            // استخدمنا الريبو بدل الكونيكست مباشرة
            var orders = await _repo.GetAllAsync();

            // فلترة الأوردرات الخاصة بالمريض + تحميل المنتجات المرتبطة
            return orders
                   .Where(o => o.P_Id == patientId)
                   .Select(o =>
                   {
                       // تأكد إن المنتجات محملة
                       o.OrderProducts = o.OrderProducts ?? new List<Order_Product>();
                       return o;
                   })
                   .ToList();
        }

    }

}
