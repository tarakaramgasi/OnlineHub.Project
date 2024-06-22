using OnlineHub.Entities;

namespace OnlineHub.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(int userId);
    }
    
}
