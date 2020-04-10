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
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetUsers();
        }


        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }
    }
}
