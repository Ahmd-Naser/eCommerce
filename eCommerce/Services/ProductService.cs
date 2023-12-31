﻿using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class ProductService : IProductService
    {   
        ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context) { 
            _context = context;
        }

        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var Products = await _context.Products.ToListAsync();

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
                    });
            }


            return products;
        }

        public async Task<Product> GetById(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            return product;
        }

        public async Task<Product> GetByName(string name)
        {
            var product= await _context.Products.FirstOrDefaultAsync(p => p.Name ==  name);

            return product;
        }

        public Product Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();

            return product;
        }
    }
}
