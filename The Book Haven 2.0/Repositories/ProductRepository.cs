using Interface;
using Microsoft.EntityFrameworkCore;
using TheBookHaven2.Data;
using TheBookHaven2.Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookHavenDbContext _context;

        public ProductRepository(BookHavenDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
 

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products
                    .Where(p => p.IsAvailable)
                    .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task<Product> GetByISBNAsync(string isbn)
        {
            return await _context.Products
                    .FirstOrDefaultAsync(p => p.ISBN == isbn);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string? searchTerm = null, string? authorName = null)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p => p.Title.Contains(searchTerm));
            }

            if (!string.IsNullOrWhiteSpace(authorName))
            {
                query = query.Where(p => p.Author.Contains(authorName));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
