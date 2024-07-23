using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public interface ICategoriesRepo
    {
        IEnumerable<FurnitureTypeCategory> GetAllCategories();
        FurnitureTypeCategory GetCategoryById(int id);
        FurnitureTypeCategory GetCategoryByName(string name);
    }
}