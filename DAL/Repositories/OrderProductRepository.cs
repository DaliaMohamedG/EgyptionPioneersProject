using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface IOrderProductRepository : IRepository<Order_Product>
    {
        Task<List<Product>> GetProductsByOrderIdAsync(int orderId);
    }

    public class OrderProductRepository : Repository<Order_Product>, IOrderProductRepository
    {
        private readonly AppDbContext _context;
        public OrderProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByOrderIdAsync(int orderId)
        {
            return await _context.Products
                .Where(p => _context.Order_Products.Any(op => op.O_Id == orderId && op.Pr_Id == p.Pr_Id))
                .ToListAsync();
        }
    }

}
