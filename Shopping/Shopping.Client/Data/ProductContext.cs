using System.Collections.Generic;
using Shopping.Client.Models;

namespace Shopping.Client.Data
{
    public class ProductContext
    {
       public static readonly List<Product> Products = new List<Product>
        {
            new Product()
            {
                Name = "Apple iPhone 13",
                Category = "Smartphones",
                Description = "Latest Apple smartphone with A15 Bionic chip.",
                ImageFile = "iphone13.jpg",
                Price = 799.99m
            },
            new Product()
            {
                Name = "Samsung Galaxy S21",
                Category = "Smartphones",
                Description = "Flagship Samsung smartphone with Exynos 2100.",
                ImageFile = "galaxyS21.jpg",
                Price = 749.99m
            },
            new Product()
            {
                Name = "Sony WH-1000XM4",
                Category = "Headphones",
                Description = "Industry-leading noise-canceling headphones.",
                ImageFile = "sonyWH1000XM4.jpg",
                Price = 349.99m
            }
        };
    }
}
