using FruitEcommerce.API.Controllers;
using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FruitEcommerce.APITest.Controllers
{
    public class AuthenticationControllerUnitTest
    {
        [Fact]
        public void ShouldReturnNotFoundWhenUserIsInvalid()
        {
            //Arrange
            Moq.Mock<IUserService> mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetByUserNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns<User>(null);

            var authenticationController = new AuthenticationController(mockUserService.Object);

            // Act
            var result = authenticationController.Authenticate(new User());
            var objectResult = result.Result as ObjectResult;

            // Assert
            Assert.NotNull(objectResult);
            Assert.Equal(StatusCodes.Status404NotFound, objectResult.StatusCode);
            Assert.Equal("{ message = Usuário ou senha inválidos }", objectResult.Value.ToString());
        }

        [Fact]
        public void ShouldReturnTokenWhenUserIsValid()
        {
            //Arrange
            Mock<IUserService> mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.GetByUserNameAndPassword(It.IsAny<string>(), It.IsAny<string>())).Returns(
                new User { Username = "Usuario1", Password = "123456", Role = "admin" });
            mockUserService.Setup(x => x.GenerateToken(It.IsAny<User>())).Returns("token123");

            var authenticationController = new AuthenticationController(mockUserService.Object);

            // Act
            var result = authenticationController.Authenticate(new User());
            var valueToken = result.Value.GetType().GetProperty("Token").GetValue(result.Value, null);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("token123", valueToken);
        }
    }
}
