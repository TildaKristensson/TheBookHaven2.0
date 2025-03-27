using TheBookHaven2.DTO;
using TheBookHaven2.Models;

namespace TheBookHaven2.ApiService
{
    public class OrderApiService
{
        private readonly HttpClient _httpClient;

        public OrderApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/order");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Order>>();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/order/{id}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var response = await _httpClient.GetAsync($"api/order/customer/{customerId}");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Order>>();
        }

        public async Task<List<CustomerOrdersDTO>> GetCustomerOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/order/customer-orders");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CustomerOrdersDTO>>();
        }

        public async Task CreateOrderAsync(CreateOrderDTO createOrderDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/order", createOrderDto);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/order/{id}", order);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/order/{id}");

            response.EnsureSuccessStatusCode();
        }

    }
}
