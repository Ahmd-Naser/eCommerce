using eCommerce.Models;

namespace eCommerce.Services
{
    public interface ICartService
    {
        Task<Cart> Add(Cart cart);

        Cart Delelte(Cart cart);

        Task<Cart> GetById(int id);

        Task<IEnumerable<Cart>> GetAll(string userId);

    }
}
