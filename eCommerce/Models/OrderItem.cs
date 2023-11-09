namespace eCommerce.Models
{
    public class OrderItem
    {
        public int OrderItemId { set; get; }
        public int Quantity { set; get; }
        public decimal price { set; get; }


        public int OrderId { set; get; }
        public Order Order { set; get; }

        public int ProductId { set; get; }
        public Product Product { set; get; }

    }
}
