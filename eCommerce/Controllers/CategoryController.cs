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
        public async Task<IActionResult> AddCategory(CategoryDto dto)
        {
            if (dto == null)
                return BadRequest();

            Category category = new Category { Name = dto.Name };

            _categoriesService.Add(category);

            return Ok(category);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync(CategoryDto dto)
        {
            if(dto == null)
                return BadRequest();

            Category category = await _categoriesService.GetByName(dto.Name);

            if (category == null)
                return BadRequest();

            _categoriesService.Delete(category);

            return Ok(category);

        }

        [HttpPut("ModifyCategory")]

        public async Task<IActionResult> ChangeName(CategoryChangeDto dto)
        {
            Category category = await _categoriesService.GetById(dto.id);

            if(category == null)
                return BadRequest();

            category.Name = dto.newName;

            return Ok(category);
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
