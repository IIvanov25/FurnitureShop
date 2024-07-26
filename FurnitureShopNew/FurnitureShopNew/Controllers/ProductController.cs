using FurnitureShopNew.DTOs;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling.Internal;

namespace FurnitureShopNew.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("getCurrentViewedProduct")]
        public async Task<IActionResult> GetCurrentViewedProduct([FromBody] ProductIdRequest request)
        {
            if (request.ProductId <= 0)
            {
                return BadRequest("Invalid productId");
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(request.ProductId);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                var productDto = new GetCurrentViewedProduct(
                    product.ProductId,
                    product.Name,
                    product.ImageUrl,
                    product.Description,
                    product.Price,
                    product.StockQuantity
                );

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost("getProductToUpdate")]
        public async Task<IActionResult> GetProductToUpdate([FromBody] ProductIdRequest request)
        {
            if (request.ProductId <= 0)
            {
                return BadRequest("Invalid productId");
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(request.ProductId);

                if (product == null)
                {
                    return NotFound("Product not found");
                }

                var productDto = new GetProductToUpdateDTO(
                    product.ProductId,
                    product.Name,
                    product.ImageUrl,
                    product.Description,
                    product.Price,
                    product.StockQuantity,
                    product.FurnitureTypeCategoryId,
                    product.RoomCategoryId
                );

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
