using EgyptionPioneersProject.Models;
using EgyptionPioneersProject.Repositories;

namespace Services.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product p);
        Task<Product?> UpdateAsync(int id, Product p);
        Task<bool> DeleteAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _repo.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task<Product> CreateAsync(Product p)
        {
            await _repo.AddAsync(p);
            return p;
        }

        public async Task<Product?> UpdateAsync(int id, Product p)
        {
            var old = await _repo.GetByIdAsync(id);
            if (old == null) return null;

            old.Pr_Name = p.Pr_Name;
            old.Pr_Description = p.Pr_Description;
            old.Pr_Price = p.Pr_Price;
            old.Pr_Stock = p.Pr_Stock;
            old.Pr_Category = p.Pr_Category;

            old.Pr_Image = p.Pr_Image;

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
