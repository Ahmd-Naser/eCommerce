using eCommerce.Data;
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

            return Categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.CategoryId == id);

            return category;
        }

        public async Task<Category> GetByName(string name)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.Name == name);

            return category;
        }

        public Category Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }
    }
}
