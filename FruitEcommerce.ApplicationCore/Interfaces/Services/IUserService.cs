using FruitEcommerce.ApplicationCore.Entities;

namespace FruitEcommerce.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        string GenerateToken(User user);
        User GetByUserNameAndPassword(string username, string password);
    }
}
