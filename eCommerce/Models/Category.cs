namespace eCommerce.Models
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string Name { set; get; }

        public ICollection<Product> Product { set; get; }
    }
}
