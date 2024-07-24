using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
    }
}