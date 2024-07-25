using FurnitureShopNew.Models;

namespace FurnitureShopNew.Repositories
{
    public class CategoriesRepo : ICategoriesRepo
    {
        private readonly ShopDbContext _context;

        public CategoriesRepo(ShopDbContext context)
        {
            _context = context;
        }

        public List<FurnitureTypeCategory> GetAllCategories()
        {
            return _context.FurnitureTypeCategories.ToList();
        }

        public void AddCategory(FurnitureTypeCategory category)
        {
            if (!_context.FurnitureTypeCategories.Contains(category))
            {
                _context.FurnitureTypeCategories.Add(category);
            }
            else throw new ArgumentException($"Category with name - {category.CategoryName} already exists.");
        }


        public void UpdateCategory(FurnitureTypeCategory oldcategory, FurnitureTypeCategory newcategory)
        {
            try
            {
                _context.FurnitureTypeCategories.Remove(oldcategory);
                _context.FurnitureTypeCategories.Add(newcategory);
            }
            catch (Exception)
            {
                throw new Exception("Error in removing old category.");
            }
        }

        public void DeleteCategory(FurnitureTypeCategory category)
        {
            if (_context.FurnitureTypeCategories.Contains(category))
            {
                _context.FurnitureTypeCategories.Remove(category);
            }
            else throw new ArgumentException($"Category with name - {category.CategoryName} doesn't exist.");
        }

        public FurnitureTypeCategory GetCategoryById(int id)
        {
            if (_context.FurnitureTypeCategories.Count() < id && id >= 0)
            {
                return _context.FurnitureTypeCategories.FirstOrDefault(c => c.FurnitureTypeCategoryId == id);
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index - {id}.");
            }
        }
        public FurnitureTypeCategory GetCategoryByName(string name)
        {
            var category = _context.FurnitureTypeCategories.FirstOrDefault(c => c.CategoryName == name);
            if (_context.FurnitureTypeCategories.Contains(category))
            {
                return _context.FurnitureTypeCategories.FirstOrDefault(c => c.CategoryName == name);
            }
            else throw new ArgumentException($"Invalid category name - {name}.");
        }
    }
}