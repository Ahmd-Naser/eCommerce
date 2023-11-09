namespace eCommerce.Models
{
    public class Order
    {
        public int OrderId { set; get; }
        public DateTime date { set; get; } = DateTime.Now;
        public decimal TotalPrice { set; get; }

        public ICollection<OrderItem> OrderItem { set; get; }

        public string ApplicationUserId { set; get; }
        public ApplicationUser ApplicationUser { set; get; }

        //public int ShipmentId { set; get; }
        //public Shipment Shipment { set; get; }

    }
}
