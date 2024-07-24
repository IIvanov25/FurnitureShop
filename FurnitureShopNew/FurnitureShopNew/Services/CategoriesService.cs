using FurnitureShopNew.Models;
using FurnitureShopNew.Services;

public class CategoriesService : ICategoriesService
{
public CategoriesRepo(ShopDbContext context)
        {
            _context = context;
        }
        
        List<string> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(FurnitureTypeCategory category)
{
     if(!_context.Categories.Contains(c => c.Name == name))
{
    _context.Categories.Add(category);
}
     else throw new ArgumentException($"Category with name - {category.name} already exists.");
}


public void UpdateCategory(FurnitureTypeCategory oldcategory, FurnitureTypeCategory newcategory)
{
    try
{
    _context.Categories.Remove(oldcategory);
    _context.Categories.Add(newcategory);
}
    catch(Exception)
{
    throw new Exception("Error in removing old category.");
}
}

public void DeleteCategory(FurnitureTypeCategory category)
{
     if(_context.Categories.Contains(c => c.Name == name))
{
    _context.Categories.Remove(category);
}
     else throw new ArgumentException($"Category with name - {category.name} doesn't exist.");
}

        FurnitureTypeCategory GetCategoryById(int id)
        {
            if (_context.Categories.Contains(c => c.Id == id))
            {
                return _context.Categories.FirstOrDefault(c => c.Id == id);
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index - {id}.");
            }
        }
        FurnitureTypeCategory GetCategoryByName(string name)
        {
            if (_context.Categories.Contains(c => c.Name == name))
            {
                return _context.Categories.FirstOrDefault(c => c.Name == name);
            }
            catch new ArgumentException{$"Invalid category name - {name}."}
        }
}