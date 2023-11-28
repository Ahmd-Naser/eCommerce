using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoriesService;

        public CategoryController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryNameDto dto)
        {
            if (dto == null)
                return BadRequest();

            Category category = new Category { Name = dto.Name };

            _categoriesService.Add(category);

            CategoryDto dtoEndpoint = new()
            {
                Id = category.CategoryId,
                Name = category.Name
            };

            return Ok(dtoEndpoint);

        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(CategoryNameDto dto)
        {
            if(dto == null)
                return BadRequest();

            Category category = await _categoriesService.GetByName(dto.Name);

            if (category == null)
                return BadRequest();

            _categoriesService.Delete(category);

            CategoryDto dtoEndpoint = new()
            {
                Id = category.CategoryId,
                Name = category.Name
            };

            return Ok(dtoEndpoint);

        }

        [HttpPut("ModifyCategory")]

        public async Task<IActionResult> ChangeName(CategoryDto dto)
        {
            Category category = await _categoriesService.GetById(dto.Id);

            if(category == null)
                return BadRequest();

            category.Name = dto.Name;


            return Ok(dto);
        }

        [HttpGet("AllCategories")]

        public async Task<IActionResult> getAllCategories()
        {
            var categories = await _categoriesService.GetAll();
            
            return Ok(categories);
        }

        [HttpGet("Products")]

        public async Task<IActionResult> getAllProducts(int id =0)
        {
            IEnumerable<ProductDto> products = await _categoriesService.GetProducts(id);



            return Ok(products);
        }


    }
}
