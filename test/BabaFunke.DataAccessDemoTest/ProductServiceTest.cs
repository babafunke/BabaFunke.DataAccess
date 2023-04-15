using Babafunke.DataAccessDemo.Models;
using Babafunke.DataAccessDemo.Repository;
using Babafunke.DataAccessDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabaFunke.DataAccessDemoTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly Mock<IDataRepository> _mockRepo;
        private ProductService _sut;
        private List<Product> _products;

        public ProductServiceTest()
        {
            _mockRepo = new Mock<IDataRepository>();
            _products = GetMockProducts();
            _sut = new ProductService(_mockRepo.Object);
        }

        #region Constructor Test
        [TestMethod]
        public void Constructor_ShouldThrowExceptionIfNullArgument()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _sut = new ProductService(null));
        }
        #endregion

        #region GetAllItems Tests
        [TestMethod]
        public async Task GetAllItems_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.GetAllProducts()).Returns(_products);

            var result = await _sut.GetAllItems();

            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public async Task GetAllItems_ShouldTotalCount()
        {
            _mockRepo.Setup(m => m.GetAllProducts()).Returns(_products);

            var result = await _sut.GetAllItems();

            Assert.AreEqual(result.Count(), _products.Count);
        }

        [TestMethod]
        public async Task GetAllItems_ShouldCallRepoService()
        {
            _mockRepo.Setup(m => m.GetAllProducts()).Returns(_products);

            var result = await _sut.GetAllItems();

            _mockRepo.Verify(m => m.GetAllProducts(), Times.Once);
        }
        #endregion

        #region GetItemById Tests
        [TestMethod]
        public async Task GetItemById_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.GetProduct(It.IsAny<int>())).Returns(new Product());

            var result = await _sut.GetItemById(1);

            Assert.IsInstanceOfType(result, typeof(Product));
        }

        [TestMethod]
        public async Task GetItemById_ShouldReturnProduct()
        {
            var product = _products.First();

            _mockRepo.Setup(m => m.GetProduct(It.IsAny<int>())).Returns(product);

            var result = await _sut.GetItemById(1);

            Assert.AreEqual(result.Title, product.Title);
            Assert.AreEqual(result.Id, product.Id);
            Assert.AreEqual(result.Count, product.Count);
        }

        [TestMethod]
        public async Task GetItemById_ShouldCallRepoService()
        {
            _mockRepo.Setup(m => m.GetProduct(It.IsAny<int>())).Returns(new Product());

            var result = await _sut.GetItemById(1);

            _mockRepo.Verify(m => m.GetProduct(It.IsAny<int>()), Times.Once);
        }
        #endregion

        #region CreateItem Tests
        [TestMethod]
        public async Task CreateItem_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.AddProduct(It.IsAny<Product>())).Returns(new Product());

            var result = await _sut.CreateItem(new Product());

            Assert.IsInstanceOfType(result, typeof(Product));
        }

        [TestMethod]
        public async Task CreateItem_ShouldReturnProduct()
        {
            var product = new Product { Id = 3, Title = "Title 3", Count = 1 };

            _mockRepo.Setup(m => m.AddProduct(It.IsAny<Product>())).Returns(product);

            var result = await _sut.CreateItem(product);

            Assert.AreEqual(result.Title, product.Title);
            Assert.AreEqual(result.Id, product.Id);
            Assert.AreEqual(result.Count, product.Count);
        }

        [TestMethod]
        public async Task CreateItem_ShouldCallRepoService()
        {
            var product = new Product { Id = 3, Title = "Title 3", Count = 1 };

            _mockRepo.Setup(m => m.AddProduct(It.IsAny<Product>())).Returns(product);

            var result = await _sut.CreateItem(product);

            _mockRepo.Verify(m => m.AddProduct(It.IsAny<Product>()), Times.Once);
        }
        #endregion

        #region EditItem Tests
        [TestMethod]
        public async Task EditItem_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.UpdateProduct(It.IsAny<Product>())).Returns(new Product());

            var result = await _sut.EditItem(new Product());

            Assert.IsInstanceOfType(result, typeof(Product));
        }

        [TestMethod]
        public async Task EditItem_ShouldReturnProduct()
        {
            var product = new Product { Id = 1, Title = "Title 1 Edited", Count = 1 };

            _mockRepo.Setup(m => m.UpdateProduct(It.IsAny<Product>())).Returns(product);

            var result = await _sut.EditItem(product);

            Assert.AreEqual(result.Title, product.Title);
            Assert.AreEqual(result.Id, product.Id);
            Assert.AreEqual(result.Count, product.Count);
        }

        [TestMethod]
        public async Task EditItem_ShouldCallRepoService()
        {
            var product = new Product { Id = 1, Title = "Title 1 Edited", Count = 1 };

            _mockRepo.Setup(m => m.UpdateProduct(It.IsAny<Product>())).Returns(product);

            var result = await _sut.EditItem(product);

            _mockRepo.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Once);
        }
        #endregion

        #region DeleteItem Tests
        [TestMethod]
        public async Task DeleteItem_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.DeleteProduct(It.IsAny<int>())).Returns(true);

            var result = await _sut.DeleteItem(1);

            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        public async Task DeleteItem_ShouldCallRepoService()
        {
            _mockRepo.Setup(m => m.DeleteProduct(It.IsAny<int>())).Returns(true);

            var result = await _sut.DeleteItem(1);

            _mockRepo.Verify(m => m.DeleteProduct(It.IsAny<int>()), Times.Once);
        }
        #endregion

        #region ArchiveItem Tests
        [TestMethod]
        public async Task ArchiveItem_ShouldReturnType()
        {
            _mockRepo.Setup(m => m.ArchiveProduct(It.IsAny<int>())).Returns(true);

            var result = await _sut.ArchiveItem(1);

            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        public async Task ArchiveItem_ShouldCallRepoService()
        {
            _mockRepo.Setup(m => m.ArchiveProduct(It.IsAny<int>())).Returns(true);

            var result = await _sut.ArchiveItem(1);

            _mockRepo.Verify(m => m.ArchiveProduct(It.IsAny<int>()), Times.Once);
        }
        #endregion

        private static List<Product> GetMockProducts()
        {
            return new List<Product> {
                new Product{Id = 1, Title = "Title 1", Count = 11, IsDisabled = false},
                new Product{Id = 2, Title = "Title 2", Count = 10, IsDisabled = false}
            };
        }
    }
}
