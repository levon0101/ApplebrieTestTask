using System;
using System.Collections.Generic;
using System.Linq;
using ApplebrieTestTask.WebApi.Entitities;


namespace ApplebrieTestTask.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public User GetUser(int id)
        {

            //return new User { Id = id, FirstName = "Levon", LastName = "Mardanyan" }; //todo get from db
            return _dbContext.Users.SingleOrDefault(u => u.Id == id);

        }

        public IEnumerable<User> GetUsers()
        {
            //return new List<User>
            //{
            //    new User{Id = 1, FirstName = "Levon", LastName = "Mardanyan"},
            //    new User{Id = 2, FirstName = "Grigori", LastName = "Mardanyan"},
            //    new User { Id = 3, FirstName = "Qnarik", LastName = "Mardanyan" },
            //    new User { Id = 4, FirstName = "Andrey", LastName = "Mardanyan" }
            //}; // todo get from db
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
