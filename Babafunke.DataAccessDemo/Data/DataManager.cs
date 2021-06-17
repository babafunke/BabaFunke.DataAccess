using Babafunke.DataAccessDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Babafunke.DataAccessDemo.Data
{
    public static class DataManager
    {
        public static List<Product> products = new List<Product>
        {
            new Product{Id = 1, Title = "Conversational Igbo for kids", Count = 5, IsDisabled = false},
            new Product{Id = 2, Title = "Conversational Yoruba for kids", Count = 8, IsDisabled = false}
        };

        public static List<Product> GetAllProducts()
        {
            return products.OrderBy(p => p.Id).ToList();
        }

        public static Product GetProduct(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public static Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public static Product UpdateProduct(Product product)
        {
            var existingProduct = GetProduct(product.Id);
            if (existingProduct == null)
            {
                return null;
            }

            var indexOfExistingProduct = products.IndexOf(existingProduct);
            products.RemoveAt(indexOfExistingProduct);
            products.Insert(indexOfExistingProduct,product);

            return product;
        }

        public static bool DeleteProduct(int id)
        {
            try
            {
                var existingProduct = GetProduct(id);
                if (existingProduct == null)
                {
                    return false;
                }

                products.Remove(existingProduct);

                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public static bool ArchiveProduct(int id)
        {
            try
            {
                var existingProduct = GetProduct(id);
                if (existingProduct == null)
                {
                    return false;
                }

                var indexOfExistingProduct = products.IndexOf(existingProduct);

                var archivedProduct = new Product
                {
                    Id = existingProduct.Id,
                    Title = existingProduct.Title,
                    Count = existingProduct.Count,
                    IsDisabled = true
                };

                products.RemoveAt(indexOfExistingProduct);
                products.Insert(indexOfExistingProduct, archivedProduct);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
