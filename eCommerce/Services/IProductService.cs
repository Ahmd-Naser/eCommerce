using eCommerce.Models;
using eCommerce.DTOs;
using System.Security.Cryptography;

namespace eCommerce.Services
{
    public interface IProductService
    {
        public Product Add(Product product);
        public Product Update(Product product);
        public Product Delete(Product product);
        public Task<Product> GetById(int id);
        public Task< Product> GetByName(string name);

        public Task<IEnumerable<ProductDto>> GetAll();

    }
}
