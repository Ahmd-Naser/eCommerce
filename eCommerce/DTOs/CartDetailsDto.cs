namespace eCommerce.DTOs
{
    public class CartDetailsDto
    {
        public int CartId { get; set; }
        public int Quantity { set; get; }

        public int TotalPrice { set; get; }

        public int ProductId { set; get; }
        public string ProductName { set; get; } = string.Empty;
    }
}
