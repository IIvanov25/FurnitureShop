using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using FurnitureShopNew.Services;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    [Route("controller")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet("getAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = _categoriesService.GetAllCategories();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("getCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = _categoriesService.GetCategoryById(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("getCategoryByName")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            try
            {
                var category = _categoriesService.GetCategoryByName(name);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}