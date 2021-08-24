using FruitEcommerce.ApplicationCore.Entities;

namespace FruitEcommerce.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        string GenerateToken(User user);
        User GetByUsernameAndPassword(string username, string password);
    }
}
