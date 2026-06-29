using Microsoft.EntityFrameworkCore;
using Ruvelu.Core.Entities;
using Ruvelu.Core.Interfaces;

namespace Ruvelu.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RuveluDbContext _context;

        public ProductRepository(RuveluDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
                product.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}