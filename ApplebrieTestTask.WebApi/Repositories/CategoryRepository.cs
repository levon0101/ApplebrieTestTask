using System.Collections.Generic;
using System.Linq;
using ApplebrieTestTask.WebApi.Entitities;

namespace ApplebrieTestTask.WebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Category GetCategory(int id)
        {
            return _dbContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetCategories()
        {

            return _dbContext.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void RemoveCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
         

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
