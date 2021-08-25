using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Repositories;
using FruitEcommerce.ApplicationCore.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FruitEcommerce.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var secret = _configuration.GetValue(typeof(string), "SecretKey").ToString();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _userRepository.GetByUserNameAndPassword(username, password);
        }
    }
}
