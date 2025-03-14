using Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Interface
{
    public interface IProductRepository : IRepository<Product>
{
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm = null, string authorName = null);
        Task<Product> GetByISBNAsync(string isbn);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
}
}
