using Babafunke.DataAccessDemo.Controllers;
using Babafunke.DataAccessDemo.Models;
using BabaFunke.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabaFunke.DataAccessDemoTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private readonly Mock<IRepository<Product>> _mockService;
        private readonly ProductController _controller;

        public ProductControllerTest()
        {
            _mockService = new Mock<IRepository<Product>>();
            _controller = new ProductController(_mockService.Object);
        }

        [TestMethod]
        public async Task GetAllProducts_ShouldReturnOkObjectResult()
        {
            //Arrange
            var products = GetTestProducts();

            _mockService.Setup(p => p.GetAllItems()).ReturnsAsync(products);

            //Act
            var sut = await _controller.GetAllProducts();
            var result = sut as OkObjectResult;
            var model = result?.Value as IEnumerable<Product>;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(2, model?.Count());
            Assert.AreEqual(200, result?.StatusCode);
        }

        [TestMethod]
        public async Task GetProduct_ShouldReturnOkObjectResult()
        {
            //Arrange
            var products = GetTestProducts();
            var product = products.First();
            var id = 1;

            _mockService.Setup(p => p.GetItemById(id)).ReturnsAsync(product);

            //Act
            var sut = await _controller.GetProduct(id);
            var result = sut as OkObjectResult;
            var model = result?.Value as Product;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual(1, model?.Id);
            Assert.AreEqual(200, result?.StatusCode);
        }

        [TestMethod]
        public async Task GetProduct_ShouldReturnNotFound()
        {
            //Arrange
            var products = GetTestProducts();
            var id = 3;
            var product = products.SingleOrDefault(p => p.Id == id);

            _mockService.Setup(p => p.GetItemById(id)).ReturnsAsync(product);

            //Act
            var sut = await _controller.GetProduct(id);
            var result = sut as NotFoundObjectResult;
            var model = result?.Value as Product;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            Assert.IsNull(model);
            Assert.AreEqual(404, result?.StatusCode);
        }

        [TestMethod]
        public async Task PostProduct_ShouldReturnOk()
        {
            //Arrange
            var products = GetTestProducts();
            var product = new Product
            {
                Id = 3
            };
            var response = products.SingleOrDefault(p => p.Id == product.Id);

            _mockService.Setup(p => p.GetItemById(product.Id)).ReturnsAsync(response);
            _mockService.Setup(p => p.CreateItem(product)).ReturnsAsync(response);

            //Act
            var sut = await _controller.PostProduct(product);
            var result = sut as OkObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task PostProduct_ShouldReturnBadRequest()
        {
            //Arrange
            var products = GetTestProducts();
            var product = new Product
            {
                Id = 2
            };
            var response = products.SingleOrDefault(p => p.Id == product.Id);

            _mockService.Setup(p => p.GetItemById(product.Id)).ReturnsAsync(response);
            _mockService.Setup(p => p.CreateItem(product)).ReturnsAsync(response);

            //Act
            var sut = await _controller.PostProduct(product);
            var result = sut as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutProduct_ShouldReturnOk()
        {
            //Arrange
            var id = 1;
            var product = new Product
            {
                Id = 1
            };

            _mockService.Setup(p => p.EditItem(product)).ReturnsAsync(product);

            //Act
            var sut = await _controller.PutProduct(id, product);
            var result = sut as OkObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task PutProduct_ShouldReturnBadRequest()
        {
            //Arrange
            var id = 1;
            var product = new Product
            {
                Id = 2
            };

            _mockService.Setup(p => p.EditItem(product)).ReturnsAsync(product);

            //Act
            var sut = await _controller.PutProduct(id, product);
            var result = sut as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutProduct_ShouldReturnNotFound()
        {
            //Arrange
            var products = GetTestProducts();
            var id = 3;
            var product = new Product
            {
                Id = 3
            };

            var response = products.SingleOrDefault(p => p.Id == product.Id);
            _mockService.Setup(p => p.EditItem(product)).ReturnsAsync(response);

            //Act
            var sut = await _controller.PutProduct(id, product);
            var result = sut as NotFoundObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task PatchProduct_ShouldReturnNoContent()
        {
            //Arrange
            var id = 1;

            _mockService.Setup(p => p.ArchiveItem(id)).ReturnsAsync(true);

            //Act
            var sut = await _controller.PatchProduct(id);
            var result = sut as NoContentResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task PatchProduct_ShouldReturnNotFound()
        {
            //Arrange
            var products = GetTestProducts();
            var id = 3;

            var product = products.Find(p => p.Id == id);
            var response = products.Remove(product);

            _mockService.Setup(p => p.ArchiveItem(id)).ReturnsAsync(response);

            //Act
            var sut = await _controller.PatchProduct(id);
            var result = sut as NotFoundObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public async Task DeleteProduct_ShouldReturnNoContent()
        {
            //Arrange
            var id = 1;

            _mockService.Setup(p => p.DeleteItem(id)).ReturnsAsync(true);

            //Act
            var sut = await _controller.DeleteProduct(id);
            var result = sut as NoContentResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteProduct_ShouldReturnNotFound()
        {
            //Arrange
            var products = GetTestProducts();
            var id = 3;

            var product = products.Find(p => p.Id == id);
            var response = products.Remove(product);

            _mockService.Setup(p => p.DeleteItem(id)).ReturnsAsync(response);

            //Act
            var sut = await _controller.DeleteProduct(id);
            var result = sut as NotFoundObjectResult;

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        private List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product {Id = 1, Title = "Product 1", Count = 5, IsDisabled = false},
                new Product {Id = 2, Title = "Product 2", Count = 8, IsDisabled = false}
            };
        }
    }
}
