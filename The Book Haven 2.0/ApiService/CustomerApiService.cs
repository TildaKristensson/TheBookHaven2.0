using TheBookHaven2.Models;

namespace TheBookHaven2.ApiService
{
    public class CustomerApiService
{
        private readonly HttpClient _httpClient;

        public CustomerApiService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Customer>>("api/customer");
            return response ?? new List<Customer>();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Customer>($"api/customer/{id}");
            return response;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var response = await _httpClient.GetFromJsonAsync<Customer>($"api/customer/email?email={email}");
            return response;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customer", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}", customer);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/customer/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
