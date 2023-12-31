﻿using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public sealed class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;

        public OrderService(IBaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<Order> GetOrder() =>
            _orderRepository.FindAll().OrderByDescending(x => x.Quantity * x.Price).FirstAsync();

        public Task<List<Order>> GetOrders() =>
            _orderRepository.FindByCondition(x => x.Quantity > 10).ToListAsync();
    }
}
