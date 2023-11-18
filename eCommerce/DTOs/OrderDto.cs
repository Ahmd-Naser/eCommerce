namespace eCommerce.DTOs
{
    public class OrderDto
    {
        public string UserName { set; get; }

        public int OrderId { get; set; }

        public decimal TotalPrice { set; get; }

        public IEnumerable<OrderItemDto> Items { get; set; }
    }
}
