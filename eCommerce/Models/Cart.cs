namespace eCommerce.Models
{
    public class Cart
    {
        public int CartId { set; get; }
        public int Quantity { set; get; }


        public string ApplicationUserId { set; get; }
        public ApplicationUser ApplicationUser { set; get; }

       

        public int ProductId { set; get; }
        public Product Product { set; get; }

    }
}
