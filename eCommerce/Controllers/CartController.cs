using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("AddToCart")]

        public async Task<IActionResult> Add(CartDto dto)
        {
            var cart = new Cart()
            {
                Quantity = dto.Quantity,
                ApplicationUserId = dto.UserId,
                ProductId = dto.ProductId
            };

            cart = await _cartService.Add(cart);

            return Ok(cart);
        }

        [HttpDelete("DeleteCart")]
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await  _cartService.GetById(id);

            _cartService.Delelte(cart);

            return Ok(cart);

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(userIdDto dto)
        {
            var Carts = await _cartService.GetAll(dto.userId);
            
            

            return Ok(Carts);
        }
    }
}
