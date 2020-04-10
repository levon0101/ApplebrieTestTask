using System;
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
            //return new Category{Id = id, Name = "Programmers"};
            return _dbContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            //return new List<Category>
            //{
            //    new Category{Id = 1, Name = "Programmers"},
            //    new Category{Id = 2, Name = "TeamLiders"},
            //    new Category{Id = 3, Name = "Designers"},
            //    new Category{Id = 4, Name = "Recruiters"},
            //    };

            return _dbContext.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

    }
}
