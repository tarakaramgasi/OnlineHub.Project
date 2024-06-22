namespace OnlineHub.Entities
{
    public class CartItem
    {
        public CartItem()
        {
            
        }
        public CartItem(int itemId, int quantity, decimal unitprice)
        {
            ItemId = itemId;
            Quantity = quantity;
            UnitPrice = unitprice;
        }
        public int Id { get; set; }
        public Guid CartId { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }
    }
}
