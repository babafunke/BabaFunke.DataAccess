using Babafunke.DataAccessDemo.Models;
using Babafunke.DataAccessDemo.Repository;
using BabaFunke.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Babafunke.DataAccessDemo.Services
{
    public class ProductService : SqlServerEfRepository<Product>
    {
        private readonly IDataRepository _dataRepo;

        public ProductService(IDataRepository dataRepo)
        {
            _dataRepo = dataRepo ?? throw new ArgumentNullException(nameof(dataRepo));
        }

        public override async Task<IEnumerable<Product>> GetAllItems()
        {
            var products = _dataRepo.GetAllProducts();
            return await Task.Run(() => products);
        }

        public override async Task<Product> GetItemById(int id)
        {
            var product = _dataRepo.GetProduct(id);
            return await Task.Run(() => product);
        }

        public override async Task<Product> CreateItem(Product item)
        {
            var product = _dataRepo.AddProduct(item);
            return await Task.Run(() => product);
        }

        public override async Task<Product> EditItem(Product item)
        {
            var product = _dataRepo.UpdateProduct(item);
            return await Task.Run(() => product);
        }

        public override async Task<bool> DeleteItem(int id)
        {
            var response = _dataRepo.DeleteProduct(id);
            return await Task.Run(() => response);
        }

        public override async Task<bool> ArchiveItem(int id)
        {
            var response = _dataRepo.ArchiveProduct(id);
            return await Task.Run(() => response);
        }
    }
}
