using TheBookHaven2.Models;

namespace TheBookHaven2.ApiService
{
    public class ProductApiService
{
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/product");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/product/{id}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<List<Product>> SearchProductsAsync(string? searchTerm, string? authorName)
        {
            var url = $"api/product/search?searchTerm={searchTerm}&authorName={authorName}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>();
        }

        public async Task<Product> GetProductByIsbnAsync(string isbn)
        {
            var response = await _httpClient.GetAsync($"api/product/isbn/{isbn}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<List<Product>> GetAvailableProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/product/available");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>();
        }

        public async Task CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", product);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/product/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}

