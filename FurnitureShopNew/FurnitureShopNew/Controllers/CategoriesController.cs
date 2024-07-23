using FurnitureShopNew;
using FurnitureShopNew.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShopNew.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly FurnitureTypeCategory _categories;
        private readonly CategoriesRepo _categoriesRepo;

        public CategoriesController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}