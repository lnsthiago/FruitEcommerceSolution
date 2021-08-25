using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Repositories;
using FruitEcommerce.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace FruitEcommerce.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            var users = new List<User>
            {
                new User { UserId = 1, Username = "Usuario1", Password = "123456", Role = "admin" },
                new User { UserId = 2, Username = "Usuario2", Password = "654321", Role = "view" }
            };
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
