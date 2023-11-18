using eCommerce.DTOs;
using eCommerce.Models;

namespace eCommerce.Services
{
    public interface IOrderService
    {
        Task<OrderDto> Add(IEnumerable<int> CartIds , string userId);

        Order Delete(Order order);

        Task<OrderDto> GetById(int id);

        Task< IEnumerable<OrderDto> > GetAll();
        Task< IEnumerable<OrderDto> > GetAll(string userId);
    }
}
