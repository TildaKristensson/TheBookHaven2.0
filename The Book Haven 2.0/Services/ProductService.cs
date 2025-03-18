using TheBookHaven2.Interface;
using TheBookHaven2.Models;
using TheBookHaven2.Repositories;

namespace TheBookHaven2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task AddProductAsync(Product product)
        {
            // valideringslogik?
            await _repository.AddAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            // valideringslogik?
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // valideringslogik?
            await _repository.UpdateAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _repository.GetAllAsync();

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync() => await _repository.GetAvailableProductsAsync();

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new Exception($"No product could be found with id: {id}");

            return product;
        } 

        public async Task<Product?> GetProductByISBNAsync(string isbn) => await _repository.GetByISBNAsync(isbn);

        public async Task<IEnumerable<Product>> SearchProductsAsync(string? searchTerm = null, string? authorName = null)
            => await _repository.SearchProductsAsync(searchTerm, authorName);

      
    }
}
