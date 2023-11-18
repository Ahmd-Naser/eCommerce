namespace eCommerce.DTOs
{
    public class OrderItemsDto
    {
        public string userId { set; get; }
        public IEnumerable<int> Items { get; set; }
    }
}
