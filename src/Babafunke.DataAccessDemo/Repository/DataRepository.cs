using Babafunke.DataAccessDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Babafunke.DataAccessDemo.Repository
{
    public class DataRepository : IDataRepository
    {
        public List<Product> Products = new List<Product>();

        public DataRepository()
        {
            Products = RetrieveTheMockDataFile();
        }

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProduct(int id)
        {
            var product = Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public Product AddProduct(Product product)
        {
            Products.Add(product);
            SaveTheMockDataFile(Products);
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var indexOfExistingProduct = Products.FindIndex(a => a.Id == product.Id);

            if (indexOfExistingProduct == -1)
            {
                return null;
            }

            Products.RemoveAt(indexOfExistingProduct);
            return AddProduct(product);
        }

        public bool ArchiveProduct(int id)
        {
            var existingProduct = GetProduct(id);
            if (existingProduct == null)
            {
                return false;
            }

            var indexOfExistingProduct = Products.IndexOf(existingProduct);

            var archivedProduct = new Product
            {
                Id = existingProduct.Id,
                Title = existingProduct.Title,
                Count = existingProduct.Count,
                IsDisabled = true
            };

            Products.RemoveAt(indexOfExistingProduct);
            Products.Insert(indexOfExistingProduct, archivedProduct);

            SaveTheMockDataFile(Products);

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var existingProduct = GetProduct(id);
            if (existingProduct == null)
            {
                return false;
            }

            Products.Remove(existingProduct);

            SaveTheMockDataFile(Products);

            return true;
        }

        private static List<Product> RetrieveTheMockDataFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Babafunke.DataAccessDemo.Data.products.json";

            if (string.IsNullOrEmpty(resourceName))
                throw new Exception("Missing resource name");

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            string jsonFile = reader.ReadToEnd();
            var authorList = JsonConvert.DeserializeObject<List<Product>>(jsonFile);
            return authorList;
        }

        private static void SaveTheMockDataFile(List<Product> products)
        {
            var content = JsonConvert.SerializeObject(products);
            var dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"Data/products.json");
            File.WriteAllText(dataFilePath, content);
        }

    }
}
