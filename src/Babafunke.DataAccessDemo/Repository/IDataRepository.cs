using Babafunke.DataAccessDemo.Models;
using System.Collections.Generic;

namespace Babafunke.DataAccessDemo.Repository
{
    public interface IDataRepository
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
        bool ArchiveProduct(int id);
    }
}
