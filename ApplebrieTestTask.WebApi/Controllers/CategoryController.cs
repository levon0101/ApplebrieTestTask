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
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categoriesFromDb = _categoryRepository.GetCategories();

            if (categoriesFromDb == null) return NotFound();
            
            return Ok(categoriesFromDb);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<Category> GetCategory(int id)
        {

            var categoryFromDb = _categoryRepository.GetCategory(id);

            if (categoryFromDb == null) return NotFound();
            
            return Ok(categoryFromDb);
        }


        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
            _categoryRepository.AddCategory(category);

            return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            var categoryFromDb = _categoryRepository.GetCategory(id);

            if (categoryFromDb == null) return NotFound();

            _categoryRepository.RemoveCategory(categoryFromDb);
            return NoContent();

        }


        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var categoryFromDb = _categoryRepository.GetCategory(id);

            if (categoryFromDb == null) return NotFound();


            categoryFromDb.Name = category.Name;

            _categoryRepository.SaveChanges();

            return CreatedAtRoute("GetCategory", new {id = category.Id}, categoryFromDb);
        }

    }
}