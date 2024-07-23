using FurnitureShopNew.Models;
using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrderController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null.");
            }

            _ordersService.AddOrders(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _ordersService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            _ordersService.DeleteOrders(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _ordersService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllOrdersByUser(int userId)
        {
            var user = new User { UserId = userId }; 
            var orders = _ordersService.GetAllOrdersByUser(user);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _ordersService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            if (order == null || order.OrderId != id)
            {
                return BadRequest("Order ID mismatch.");
            }

            var existingOrder = _ordersService.GetOrderById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _ordersService.UpdateOrders(order);
            return NoContent();
        }
    }
}
