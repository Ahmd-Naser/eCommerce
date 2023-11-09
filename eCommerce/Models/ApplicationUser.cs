using Microsoft.AspNetCore.Identity;

namespace eCommerce.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address { set; get; }

        public ICollection<Order> Order { set; get; }

       // public ICollection<Shipment> Shipment { set; get; }

        public ICollection<Cart> Cart { set; get; }
    }
}
