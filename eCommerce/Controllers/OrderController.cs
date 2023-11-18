using eCommerce.DTOs;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]

        public async Task<IActionResult> MakeOrder(OrderItemsDto dto)
        {
            
            var order = await _orderService.Add(dto.Items , dto.userId);

            return Ok(order);
        }


        
        

    }
}
