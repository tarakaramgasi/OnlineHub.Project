using Microsoft.EntityFrameworkCore;
using OnlineHub.Entities;
using OnlineHub.Repositories.Interfaces;
using System;
namespace OnlineHub.Repositories.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDBContext appContext
        {
            get
            {
                return _appDbContext as AppDBContext;
            }
        }
        public OrderRepository(DbContext appDbContext) : base(appDbContext)
        {
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return appContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.UserId == userId).ToList();
        }
    }
}
