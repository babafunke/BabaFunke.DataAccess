using Babafunke.DataAccessDemo.Data;
using Babafunke.DataAccessDemo.Models;
using BabaFunke.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Babafunke.DataAccessDemo.Services
{
    public class ProductService : SqlServerEfRepository<Product>
    {
        public override async Task<IEnumerable<Product>> GetAllItems()
        {
            var products = DataManager.GetAllProducts();
            return await Task.Run(() => products);
        }

        public override async Task<Product> GetItemById(int id)
        {
            var product = DataManager.GetProduct(id);
            return await Task.Run(() => product);
        }

        public override async Task<Product> CreateItem(Product item)
        {
            var product = DataManager.AddProduct(item);
            return await Task.Run(() => product);
        }

        public override async Task<Product> EditItem(Product item)
        {
            var product = DataManager.UpdateProduct(item);
            return await Task.Run(() => product);
        }

        public override async Task<bool> DeleteItem(int id)
        {
            var response = DataManager.DeleteProduct(id);
            return await Task.Run(() => response);
        }

        public override async Task<bool> ArchiveItem(int id)
        {
            var response = DataManager.ArchiveProduct(id);
            return await Task.Run(() => response);
        }
    }
}
