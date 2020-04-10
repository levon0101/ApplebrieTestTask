using System.Collections.Generic;
using ApplebrieTestTask.WebApi.Entitities;

namespace ApplebrieTestTask.WebApi.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void DeleteUser(User user);
        void SaveChanges();
    }
}