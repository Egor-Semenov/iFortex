using System.Linq.Expressions;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Order> FindAll() =>
            _dbContext.Orders;

        public IQueryable<Order> FindByCondition(Expression<Func<Order, bool>> expression) =>
            _dbContext.Orders.Where(expression);
    }
}
