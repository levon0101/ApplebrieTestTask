using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Entitities;

namespace ApplebrieTestTask.WebApi.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);
        void DeleteCategory(Category category);
    }
}