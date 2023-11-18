using eCommerce.Data;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> Add(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            _context.SaveChanges();

            return cart;
        }

        public Cart Delelte(Cart cart)
        {
            _context.Remove(cart);
            _context.SaveChanges();

            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAll(string userId)
        {
            var cartItems = await _context.Carts.Where(c => c.ApplicationUserId == userId).ToListAsync();


            return cartItems;
        }

        public async Task<Cart> GetById(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id);

            return cart;
        }
    }
}
