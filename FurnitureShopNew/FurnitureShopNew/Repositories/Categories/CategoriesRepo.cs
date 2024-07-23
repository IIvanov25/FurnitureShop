using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public class CategoriesRepo : ICategoriesRepo
    {
        IEnumerable<FurnitureTypeCategory> ICategoriesRepo.GetAllCategories()
        {
            return Enum.GetValues(typeof(FurnitureTypeCategory))
                       .Cast<FurnitureTypeCategory>()
                       .ToList();
        }

        FurnitureTypeCategory ICategoriesRepo.GetCategoryById(int id)
        {
            if (Enum.IsDefined(typeof(FurnitureTypeCategory), id))
            {
                return (FurnitureTypeCategory)id;
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index - {id}.");
            }
        }
        FurnitureTypeCategory ICategoriesRepo.GetCategoryByName(string name)
        {
            if (Enum.TryParse(name, true, out FurnitureTypeCategory category))
            {
                return category;
            }
            else
            {
                throw new ArgumentException($"Invalid category name - {name}.");
            }
        }
    }
}