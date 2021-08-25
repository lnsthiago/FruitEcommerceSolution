using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitEcommerce.API.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Buscar Token
        /// </summary>
        /// <remarks>
        /// Exemplo de Requisição:
        ///     
        ///     {
        ///        "UserName": "Usuario1",
        ///        "Password": "123456"
        ///     }
        ///     
        /// ou 
        ///
        ///     {
        ///        "UserName": "Usuario2",
        ///        "Password": "654321"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Retorna token para autenticação</response>
        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = _userService.GetByUsernameAndPassword(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _userService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
