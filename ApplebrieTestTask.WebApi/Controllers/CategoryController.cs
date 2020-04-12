using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Dto;
using ApplebrieTestTask.WebApi.Entitities;
using ApplebrieTestTask.WebApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplebrieTestTask.WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesFromDb = _categoryRepository.GetCategories();

            if (categoriesFromDb == null) return NotFound();
            
            
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesFromDb));
        }


        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<CategoryDto> GetCategory(int id)
        {

            var categoryFromDb = _categoryRepository.GetCategory(id);

            if (categoryFromDb == null) return NotFound();

            
            return Ok(_mapper.Map<CategoryDto>(categoryFromDb));
        }


        [HttpPost]
        public IActionResult CreateCategory([FromBody]CategoryDto category)
        {

            var categoryEntity = _mapper.Map<Category>(category);
            _categoryRepository.AddCategory(categoryEntity);

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("GetCategory", new { id = category.Id }, categoryToReturn);
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
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDto category)
        {
            var categoryFromDb = _categoryRepository.GetCategory(id);

            if (categoryFromDb == null) return NotFound();


            categoryFromDb.Name = category.Name;

            _categoryRepository.SaveChanges();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryFromDb);

            return CreatedAtRoute("GetCategory", new {id = category.Id}, categoryToReturn);
        }

    }
}