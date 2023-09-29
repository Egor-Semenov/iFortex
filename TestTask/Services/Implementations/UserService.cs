using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Services.Interfaces;
using TestTask.Enums;
using TestTask.Repositories.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Order> _orderRepository;

        public UserService(IBaseRepository<User> userRepository, IBaseRepository<Order> orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public async Task<User> GetUser()
        {
            var mostOrdersCount = _orderRepository.FindAll().GroupBy(x => x.UserId).ToList().Max(x => x.Count());

            return await _userRepository.FindByCondition(x => x.Orders.Count() == mostOrdersCount).FirstAsync();
        }

        public async Task<List<User>> GetUsers() =>
            await _userRepository.FindByCondition(x => x.Status == UserStatus.Inactive).ToListAsync();
    }
}
