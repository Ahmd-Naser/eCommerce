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

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto dto)
        {
            if (dto == null)
                return BadRequest();

            Category category = new Category { Name = dto.Name };

            _categoriesService.Add(category);

            return Ok(category);
        }
    }
}
