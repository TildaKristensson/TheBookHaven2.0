using Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
{
        Task<Customer> GetByEmailAsync(string email);
}
}
