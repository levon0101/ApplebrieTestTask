using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Entitities;
using ApplebrieTestTask.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApplebrieTestTask.WebApi.Controllers
{
    [ApiController]
    [Route(("api/users"))]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_userRepository.GetUsers());
        }


        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetUser(int id)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();

            return Ok(userFromDb);
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            _userRepository.AddUser(user);
            return CreatedAtRoute("GetUser",new{id=user.Id}, user);
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            var userFromDb = _userRepository.GetUser(id);
            
            if (userFromDb == null) NotFound();
            
            _userRepository.DeleteUser(userFromDb);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) NotFound();


            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.CategoryId = user.CategoryId;

            _userRepository.SaveChanges();


            return CreatedAtRoute("GetUser", new {id = id}, userFromDb);
        }
    }
}
