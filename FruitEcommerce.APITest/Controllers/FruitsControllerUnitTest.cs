using FruitEcommerce.API.Controllers;
using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FruitEcommerce.APITest.Controllers
{
    public class FruitsControllerUnitTest
    {
        [Fact]
        public void ShouldReturnNotFoundWhenGetNonExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns<Fruit>(null);

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.GetFruit(0);
            var statusCodeResult = result.Result as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
        }

        [Fact]
        public void ShouldReturnFruitWhenGetExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Fruit { FruitId = 1 });

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.GetFruit(1);
            var resultFruit = result.Value as Fruit;

            // Assert
            Assert.NotNull(resultFruit);
            Assert.Equal(1, resultFruit.FruitId);
        }

        [Fact]
        public void ShouldReturnBadRequestWhenPutFruitWithDifferentId()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.PutFruit(1, new Fruit {FruitId = 2 });
            var statusCodeResult = result as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, statusCodeResult.StatusCode);
        }

        [Fact]
        public void ShouldReturnNotFoundWhenPutNonExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns<Fruit>(null);

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.PutFruit(2, new Fruit { FruitId = 2 });
            var statusCodeResult = result as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
        }

        [Fact]
        public void ShouldExecuteUpdateWhenPutExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Fruit { FruitId = 1 });

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.PutFruit(2, new Fruit { FruitId = 2 });
            
            // Assert
            mockFruitService.Verify(mock => mock.Update(It.IsAny<Fruit>()), Times.Once());
        }

        [Fact]
        public void ShouldReturnNotFoundWhenRemoveNonExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns<Fruit>(null);

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.DeleteFruit(1);
            var statusCodeResult = result as StatusCodeResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
        }

        [Fact]
        public void ShouldExecuteRemoveWhenRemoveExistingFruit()
        {
            //Arrange
            Mock<IFruitService> mockFruitService = new Mock<IFruitService>();
            mockFruitService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Fruit { FruitId = 1 });

            var fruitsController = new FruitsController(mockFruitService.Object);

            // Act
            var result = fruitsController.DeleteFruit(1);

            // Assert
            mockFruitService.Verify(mock => mock.Remove(It.IsAny<Fruit>()), Times.Once());
        }
    }
}
