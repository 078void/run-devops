using MongoDB.Driver;
using Shopping.API.Models;
using System.Collections.Generic;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            Console.WriteLine("=== ProductContext 建構函式被調用 ===");

            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            var collectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName");

            Console.WriteLine($"連接字串: {connectionString}");
            Console.WriteLine($"資料庫名稱: {databaseName}");
            Console.WriteLine($"集合名稱: {collectionName}");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            Products = database.GetCollection<Product>(collectionName);

            // 檢查 MongoDB 連接
            try
            {
                var count = Products.CountDocuments(FilterDefinition<Product>.Empty);
                Console.WriteLine($"MongoDB 中的產品數量: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MongoDB 連接錯誤: {ex.Message}");
            }

            Console.WriteLine("=== ProductContext 建構完成 ===");

            SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            //if (!existProduct)
            //{
            //    productCollection.InsertManyAsync(GetPreconfiguredProducts());
            //}
        }
        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "ERROR: 1",
                    Category = "Smart Phone",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years.",
                    ImageFile = "product-1.png",
                    Price = 950.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "ERROR: 2",
                    Category = "Smart Phone",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years.",
                    ImageFile = "product-2.png",
                    Price = 840.00M
                }
            };
        }
    }
}
