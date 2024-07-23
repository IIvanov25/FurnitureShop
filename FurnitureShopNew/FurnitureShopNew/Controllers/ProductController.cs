using FurnitureShopNew.Models;
using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
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

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            _productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            //_productService.DeleteProducts(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            //var products = _productService.GetAllProducts();
            return Ok();
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllOrdersByUser(int userId)
        {
            var user = new User { UserId = userId }; 
            //var orders = _productService.GetAllProductsByUser(user);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _productService.GetProductById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Product product)
        {
            if (product == null || product.ProductId != id)
            {
                return BadRequest("Order ID mismatch.");
            }

            var existingOrder = _productService.GetProductById(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            //_productService.UpdateProducts(product);
            return NoContent();
        }
    }
}
