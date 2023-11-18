using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDto> Add(IEnumerable<int> CartIds , string userId)
        {
            Order order = new Order()
            {
                ApplicationUserId = userId,

            };

            _context.Add(order);
            _context.SaveChanges();

            foreach(var cartId in CartIds)
            {   
                Cart cart = await _context.Carts.Where(c => c.CartId == cartId).FirstOrDefaultAsync();

                if (cart is null)
                    continue;

                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == cart.ProductId);
                decimal ProductPrice = product.Price;

                OrderItem orderItem = new OrderItem()
                {
                    Quantity = cart.Quantity,
                    price = cart.Quantity * ProductPrice,
                    OrderId = order.OrderId,
                    ProductId = product.ProductId
                };

                _context.Add(orderItem);

                _context.Remove(cart);

            }   
            
            _context.SaveChanges();

            return toOrderDto( order) ;
        }

        public Order Delete(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();

            return order;
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders = await _context.Orders.ToListAsync();

            List<OrderDto> ans = new();

            foreach (var order in orders)
            {
                ans.Add(toOrderDto(order));
            }

            return ans;

        }

        public async Task<IEnumerable<OrderDto>> GetAll(string userId)
        {
            var orders = await _context.Orders.Where(o => o.ApplicationUserId == userId).ToListAsync();
            List<OrderDto> ans = new();

            foreach (var order in orders)
            {
                ans.Add(toOrderDto(order));
            }

            return ans;
        }

        public async Task<OrderDto> GetById(int id)
        {

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);

            return toOrderDto( order );

        }


        public OrderDto toOrderDto(Order order)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == order.ApplicationUserId);
            string username = user.UserName;

            var items = _context.OrderItems.Where(o=> o.OrderId == order.OrderId).ToList();

            List<OrderItemDto> Items = new List<OrderItemDto>();

            foreach(var item in items)
            {

                var product = _context.Products.FirstOrDefault(p =>  p.ProductId == item.ProductId);

                var itemDto = new OrderItemDto()
                {
                    Price = item.price,
                    Quantity = item.Quantity,
                    ProductName = product.Name
                    
                };

                Items.Add(itemDto);
            }

            OrderDto dto = new OrderDto()
            {
                UserName = username,
                OrderId = order.OrderId,
                TotalPrice = order.TotalPrice,
                Items = Items
            };

            return dto;
        }
    }
}
