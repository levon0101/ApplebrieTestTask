using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Dto;
using ApplebrieTestTask.WebApi.Entitities;
using ApplebrieTestTask.WebApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplebrieTestTask.WebApi.Controllers
{
    [ApiController]
    [Route(("api/users"))]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var coursesFromRepo = _userRepository.GetUsers();

            if (coursesFromRepo == null) return NotFound();


            return Ok(_mapper.Map<IEnumerable<UserDto>>(coursesFromRepo));
        }


        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();

            return Ok(_mapper.Map<User,UserDto>(userFromDb));
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody]UserDto user)
        {
            var userEntity = _mapper.Map<User>(user);

            _userRepository.AddUser(userEntity);

            var userToReturn = _mapper.Map<UserDto>(userEntity);


            return CreatedAtRoute("GetUser",new{id=user.Id}, userToReturn);
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            var userFromDb = _userRepository.GetUser(id);
            
            if (userFromDb == null) return NotFound();
            
            _userRepository.DeleteUser(userFromDb);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto user)
        {
            var userFromDb = _userRepository.GetUser(id);

            if (userFromDb == null) return NotFound();


            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.CategoryId = user.CategoryId;

            _userRepository.SaveChanges();

            var userToReturn = _mapper.Map<UserDto>(userFromDb);

            return CreatedAtRoute("GetUser", new {id = id}, userToReturn);
        }
    }
}
