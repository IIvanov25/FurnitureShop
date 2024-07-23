using System.Collections.Generic;
using System.Linq;

namespace FurnitureShopNew.Repositories.Categories
{
    public class CategoriesRepo : ICategoriesRepo
    {
        private List<FurnitureTypeCategory> _categories;

        public CategoriesRepo()
        {
            _categories = Enum.GetValues(typeof(FurnitureTypeCategory)).Cast<FurnitureTypeCategory>().ToList();
        }

        public IEnumerable<FurnitureTypeCategory> GetAllCategories()
        {
            return Enum.GetValues(typeof(FurnitureTypeCategory)).Cast<FurnitureTypeCategory>().ToList();
        }

        public FurnitureTypeCategory GetCategoryById(int id)
        {
            if (Enum.IsDefined(typeof(FurnitureTypeCategory), id))
            {
                
                return (FurnitureTypeCategory)id;
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }
        }

            public void AddCategory(FurnitureTypeCategory category)
            {
                _categories.Add(category);
            }

        public void UpdateCategory(FurnitureTypeCategory categoryold, FurnitureTypeCategory categorynew)
        {
            _categories.Remove(categoryold);
            _categories.Add(categorynew);
        } // taka li trqbva da e idk? --Alex (AusP3r1sh)

        public void DeleteCategory(FurnitureTypeCategory category)
        {
            _categories.Remove(category);
        }
    }
}