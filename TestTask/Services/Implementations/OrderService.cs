using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;

        public OrderService(IBaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrder() =>
            await _orderRepository.FindAll().OrderByDescending(x => x.Quantity * x.Price).FirstAsync();

        public async Task<List<Order>> GetOrders() =>
            await _orderRepository.FindByCondition(x => x.Quantity > 10).ToListAsync();
    }
}
