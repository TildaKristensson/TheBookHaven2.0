﻿using TheBookHaven2.DTO;
using TheBookHaven2.Models;

namespace TheBookHaven2.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task AddOrderAsync(CreateOrderDTO createOrderDto);
        Task<bool> UpdateOrderAsync(int orderId, Order order);
        Task DeleteOrderAsync(int orderId);
    }
}