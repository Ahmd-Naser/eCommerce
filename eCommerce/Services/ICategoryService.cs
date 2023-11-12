using eCommerce.DTOs;
using eCommerce.Models;

namespace eCommerce.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> GetByName(string name);

        Category Update(Category category);
        Category Add(Category category);

        Category Delete(Category category);

         Task<IEnumerable<ProductDto>> GetProducts(int id = 0);
    }
}
