using Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Interface
{
    public interface IOrderRepository : IRepository<Order>
{
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Order?> GetOrderWithDetailsAsync(int orderId);
}
}
