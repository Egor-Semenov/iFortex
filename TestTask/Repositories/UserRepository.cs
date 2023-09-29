using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Data;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<User> FindAll() =>
            _dbContext.Users.Include(x => x.Orders);


        public IQueryable<User> FindByCondition(Expression<Func<User, bool>> expression) =>
            _dbContext.Users.Include(x => x.Orders).Where(expression);
    }
}
