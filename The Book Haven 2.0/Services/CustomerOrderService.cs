using TheBookHaven2.DTO;
using TheBookHaven2.Interface;

namespace TheBookHaven2.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerOrderService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }
        public async Task<List<CustomerOrdersDTO>> GetCustomerOrdersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerOrders = new List<CustomerOrdersDTO>();

            foreach (var customer in customers)
            {
                var orders = await _orderRepository.GetOrdersByCustomerIdAsync(customer.Id);

                customerOrders.Add(new CustomerOrdersDTO
                {
                    CustomerId = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Orders = orders.ToList()
                });
            }
            return customerOrders;
        }

        
    }
}
