using EgyptionPioneersProject.Data;

namespace EgyptionPioneersProject.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task DeleteAsync(Product old);
        Task UpdateAsync(Product old);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task DeleteAsync(Product old)
        {
            _dbSet.Remove(old);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product old)
        {
            _dbSet.Update(old);
            await _context.SaveChangesAsync();
        }
    }
}
