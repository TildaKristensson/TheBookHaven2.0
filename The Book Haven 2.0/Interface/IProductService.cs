using TheBookHaven2.Models;

namespace TheBookHaven2.Interface
{
    public interface IProductService
{
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string? searchTerm = null, string? authorName = null);
        Task<Product?> GetProductByISBNAsync(string isbn);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
