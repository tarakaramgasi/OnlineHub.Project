using Microsoft.EntityFrameworkCore;
using OnlineHub.Entities;
using OnlineHub.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHub.Repositories.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        //Property Injection
        private AppDBContext appContext
        {
            get
            {
                return _appDbContext as AppDBContext;
            }
        }
        public CartRepository(DbContext db) : base(db)
        {

        }
        public Cart GetCart(Guid cartId)
        {
            return appContext.Carts.Include("Items").Where(x => x.Id == cartId && x.IsActive == true).FirstOrDefault();
        }
        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appContext.CartItems.Where(x => x.CartId == cartId && x.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        public int UpdateQuanity(Guid cartId, int itemId, int quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == itemId)
                    {
                        flag = true;
                        //Minus the quantity
                        if (quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += quantity;
                        else if (quantity > 0)
                            cart.Items[i].Quantity += quantity;
                        break;
                    }
                }
                if (flag)
                    return appContext.SaveChanges();
            }
            return 0;
        }
        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return appContext.SaveChanges();
        }
    }
}
