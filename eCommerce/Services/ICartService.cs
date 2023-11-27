using eCommerce.DTOs;
using eCommerce.Models;

namespace eCommerce.Services
{
    public interface ICartService
    {
        Task<CartDetailsDto> Add(Cart cart);

        CartDetailsDto Delelte(Cart cart);

        Task<Cart> GetById(int id);
        Task<CartDetailsDto> GetByIdWithDetails(int id);


        Task<IList<CartDetailsDto>> GetAll(string userId);

    }
}
