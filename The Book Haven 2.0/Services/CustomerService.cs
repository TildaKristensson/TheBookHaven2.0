using TheBookHaven2.Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _repository.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            await _repository.UpdateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() 
            => await _repository.GetAllAsync();

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
            => await _repository.GetByEmailAsync(email);

        public async Task<Customer?> GetCustomerByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        
    }
}
