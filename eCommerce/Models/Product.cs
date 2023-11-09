namespace eCommerce.Models
{
    public class Product
    {
        public int ProductId { set; get; }
        public string SKU { set; get; }
        public string Description { set; get; }
        public int Price { set; get; }
        public int Stock { set; get; }

      

        public ICollection<Cart> Cart { set; get; }


        public int CategoryId { set; get; }
        public Category Category { set; get; }

       

        public ICollection<OrderItem> OrderItem { set; get; }

    }
}
