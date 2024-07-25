using FurnitureShopNew.DTOs;
using FurnitureShopNew.Models;
using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();

                var productDtos = products.Select(p => new GetAllProductsDTO(
                    p.ProductId,
                    p.Name,
                    p.ImageUrl,
                    p.Description,
                    p.Price,
                    p.StockQuantity,
                    p.FurnitureTypeCategoryId
                )).ToList();

                return Ok(productDtos);
            }
            catch (Exception ex)
            {
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
                    product.FurnitureTypeCategoryId
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
