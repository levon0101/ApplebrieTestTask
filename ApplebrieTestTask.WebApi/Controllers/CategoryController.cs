using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Entitities;
using ApplebrieTestTask.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApplebrieTestTask.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return _categoryRepository.GetCategory(id);
        }


    }
}