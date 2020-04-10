using System;
using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Entitities;

namespace ApplebrieTestTask.WebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        public Category GetCategory(int id)
        {
            return new Category{Id = id, Name = "Programmers"};
        }

        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category{Id = 1, Name = "Programmers"},
                new Category{Id = 2, Name = "TeamLiders"},
                new Category{Id = 3, Name = "Designers"},
                new Category{Id = 4, Name = "Recruiters"},
                };
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
