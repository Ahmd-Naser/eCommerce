using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private ProductDto mapToDto (Product product)
        {
            ProductDto dto = new ProductDto()
            {
                Description = product.Description,
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };

            return dto;
        }

        [HttpPost("AddProduct")]

        public IActionResult AddProduct(ProductDto dto)
        {
            if (dto == null)
                return BadRequest();

            Product product = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };

            _productService.Add(product);



            return Ok(mapToDto(product));
        }


        [HttpPut("ModifyProduct")]

        public async Task<IActionResult> EditProduct(ProductDto dto)
        {
            if(dto == null)
                return BadRequest();

            var product = await _productService.GetById((int) dto.ProductId);

            mapProduct(product, dto);



            return Ok(mapToDto(product));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            Product product = await _productService.GetById(id);

            if(product == null)
                return BadRequest("Id is not found");

            return Ok(mapToDto(product));
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            Product product = await _productService.GetByName(name);

            if (product == null)
                return BadRequest("Name is not found");

            return Ok(mapToDto(product));
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
           IEnumerable<ProductDto> products = await _productService.GetAll();

            return Ok(products);
        }

        [HttpDelete("Delete")]

        public async Task< IActionResult > Delete(int id)
        {
            Product product = await _productService.GetById(id);

            if (product == null)
                return BadRequest("Id is not found");

            _productService.Delete(product);

            return Ok(product);

        }

        // temporary before implemetn auto mapper
        private void mapProduct(Product product ,  ProductDto dto)
        {
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.CategoryId = dto.CategoryId;
        }
    }
}
