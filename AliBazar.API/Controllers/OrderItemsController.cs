using AliBazar.Application.Services.OrderItemsServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OderIdemCreateDTO orderItemDTO)
        {
            var result = await _orderItemService.CreateOrderItem(orderItemDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            return Ok(_orderItemService.GetAllOrderItems());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(long id)
        {
            var result = await _orderItemService.DeleteOrderItemById(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(long id)
        {
            var result = await _orderItemService.GetOrderItemById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(long id, OderIdemUpdateDTO oderIdemDTO)
        {
            var result = await _orderItemService.UpdateOrderItemById(id, oderIdemDTO);
            return Ok(result);
        }
    }
}
