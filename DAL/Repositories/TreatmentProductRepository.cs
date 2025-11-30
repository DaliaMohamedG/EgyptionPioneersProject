using EgyptionPioneersProject.Data;
using EgyptionPioneersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptionPioneersProject.Repositories
{
    public interface ITreatmentProductRepository : IRepository<Treatment_Product>
    {
        Task<List<Product>> GetProductsByTreatmentIdAsync(int treatmentId);
    }

    public class TreatmentProductRepository : Repository<Treatment_Product>, ITreatmentProductRepository
    {
        private readonly AppDbContext _context;
        public TreatmentProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByTreatmentIdAsync(int treatmentId)
        {
            return await _context.Products
                .Where(p => _context.Treatment_Products.Any(tp => tp.T_Id == treatmentId && tp.Pr_Id == p.Pr_Id))
                .ToListAsync();
        }
    }

}
