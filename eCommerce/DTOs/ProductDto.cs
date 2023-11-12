namespace eCommerce.DTOs
{
    public class ProductDto
    {
        public int ?ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int Price { set; get; }
        public int CategoryId { set; get; }

        public int Stock { set; get; }
    }
}
