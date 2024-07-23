using FurnitureShopNew.Models;
using FurnitureShopNew.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    public class CategoriesController : ControllerBase
    {
        private readonly FurnitureTypeCategory _categories;
        private readonly CategoriesRepo _categoriesRepo;

        public CategoriesController(FurnitureTypeCategory categories, CategoriesRepo categoriesRepo)
        {
            _categories = categories;
            _categoriesRepo = categoriesRepo;
        }
    }
}