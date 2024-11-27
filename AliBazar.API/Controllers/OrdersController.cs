using AliBazar.Application.Services.OrderServices;
using AliBazar.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AliBazar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderCreteDTO categoryDTO)
        {
            var result = await _orderService.CreateOrder(categoryDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(long id, [FromForm] OrderUpdateDTO categoryDTO)
        {
            var result = await _orderService.UpdateOrderById(id, categoryDTO);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _orderService.GetOrderById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrder(long id)
        {
            var result = await _orderService.DeleteOrderById(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
