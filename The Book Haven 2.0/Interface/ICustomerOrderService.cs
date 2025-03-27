using TheBookHaven2.DTO;

namespace TheBookHaven2.Interface
{
    public interface ICustomerOrderService
{
        Task<List<CustomerOrdersDTO>> GetCustomerOrdersAsync();
}
}
