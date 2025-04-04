﻿using TheBookHaven2.DTO;
using TheBookHaven2.Interface;
using TheBookHaven2.Models;

namespace TheBookHaven2.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task AddOrderAsync(CreateOrderDTO createOrderDto)
        {
            var order = new Order
            {
                CustomerId = createOrderDto.CustomerId,
                OrderDetails = createOrderDto.OrderDetails.Select(od => new OrderDetails
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity
                }).ToList(),
                 OrderDate = DateTime.Now,
                TotalPrice = createOrderDto.TotalPrice,
            };
            await _repository.AddAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _repository.DeleteAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _repository.GetAllAsync();

        public async Task<Order?> GetOrderByIdAsync(int orderId) => await _repository.GetByIdAsync(orderId);

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId) => await _repository.GetOrdersByCustomerIdAsync(customerId);

        public async Task<bool> UpdateOrderAsync(int orderId, Order order)
        {
            if (orderId != order.Id)
            {
                return false;
            }

            await _repository.UpdateAsync(order);
            return true;
        }
    }
}
