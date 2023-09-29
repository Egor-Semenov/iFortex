using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;
using TestTask.Repositories.Interfaces;

namespace TestTask.Services.Implementations
{
    public sealed class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Order> _orderRepository;

        public UserService(IBaseRepository<User> userRepository, IBaseRepository<Order> orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public Task<User> GetUser()
        {
            var maxOrdersCount = _orderRepository.FindAll().GroupBy(x => x.UserId).ToList().Max(x => x.Count());

            return _userRepository.FindByCondition(x => x.Orders.Count() == maxOrdersCount).FirstAsync();
        }

        public Task<List<User>> GetUsers() =>
            _userRepository.FindByCondition(x => x.Status == UserStatus.Inactive).ToListAsync();
    }
}
