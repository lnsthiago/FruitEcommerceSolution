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

        public User GetByUsernameAndPassword(string username, string password)
        {
            var users = new List<User>
            {
                new User { UserId = 1, Username = "batman", Password = "batman", Role = "manager" },
                new User { UserId = 2, Username = "robin", Password = "robin", Role = "employee" }
            };
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
