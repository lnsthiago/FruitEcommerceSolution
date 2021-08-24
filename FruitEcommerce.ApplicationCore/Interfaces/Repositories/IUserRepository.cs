using FruitEcommerce.ApplicationCore.Entities;

namespace FruitEcommerce.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsernameAndPassword(string username, string password);
    }
}
