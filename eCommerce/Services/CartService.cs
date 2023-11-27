using eCommerce.Data;
using eCommerce.DTOs;
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

        public async Task<CartDetailsDto> Add(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            _context.SaveChanges();

            return convert(cart);
        }

        public CartDetailsDto Delelte(Cart cart)
        {
            _context.Remove(cart);
            _context.SaveChanges();

            return convert(cart);
        }

        public async Task<IList<CartDetailsDto>> GetAll(string userId)
        {
            var cartItems = await _context.Carts.Where(c => c.ApplicationUserId == userId).ToListAsync();

            var items = new List<CartDetailsDto>();

            foreach (var cartItem in cartItems)
            {
                items.Add(convert(cartItem));
            }

            return items;
        }

        public async Task<Cart> GetById(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id);

            return cart;
        }
        public async Task<CartDetailsDto> GetByIdWithDetails(int id)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == id);

            return convert(cart);
        }

        private CartDetailsDto convert(Cart cart)
        {
            var product = _context.Products.FirstOrDefault(p =>  p.ProductId == cart.ProductId);

            

            var cartDetails = new CartDetailsDto()
            {
                CartId = cart.CartId,
                Quantity = cart.Quantity,
                TotalPrice = product.Price * cart.Quantity,
                ProductId = product.ProductId,
                ProductName = product.Name
            };

            return cartDetails;
        }

    }
}
