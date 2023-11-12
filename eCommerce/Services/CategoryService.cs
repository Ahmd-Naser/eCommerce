using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            _context.AddAsync(category);
            _context.SaveChanges();

            return category;
        }

        public Category Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var Categories = await _context.Categorys.OrderBy(c => c.Name).ToListAsync();
           
            if(Categories is null)
                Categories = new List<Category>();


            return Categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;
        }

        public async Task<Category> GetByName(string name)
        {
            Category category = await _context.Categorys.FirstOrDefaultAsync(c => c.Name == name);

            return category;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(int id = 0)
        {
            var Products = await _context.Products.Where(p => p.CategoryId == id || id == 0).ToListAsync();

            List<ProductDto> products = new List<ProductDto>();

            foreach (var product in Products)
            {
                products.Add(
                    new ProductDto
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Stock = product.Stock,
                        CategoryId = product.CategoryId
                    } );
            }

            return products;
        }

        public Category Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }
    }
}
