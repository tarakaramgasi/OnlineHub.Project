using OnlineHub.Entities;

namespace OnlineHub.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid cartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuanity(Guid cartId, int itemId, int quantity);
        int UpdateCart(Guid cartId, int userId);
    }
}
