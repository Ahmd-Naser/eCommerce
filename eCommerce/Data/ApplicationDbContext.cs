using eCommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> Users { set;get; }

        public DbSet<Cart> Carts { set; get; }
        public DbSet<Category> Categorys { set; get; }


        public DbSet<Order> Orders { set; get; }

        public DbSet<Product> Products { set; get; }



    }
}
