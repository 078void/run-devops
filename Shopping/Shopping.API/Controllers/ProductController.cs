using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;

        public ProductController(ILogger<ProductController> logger,ProductContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                var products = await _context.Products.Find(p => true).ToListAsync();
                Console.WriteLine($"從 MongoDB 獲取到 {products.Count()} 個產品");

                foreach (var product in products)
                {
                    Console.WriteLine($"產品: {product.Name}");
                }

                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"獲取產品時發生錯誤: {ex.Message}");
                throw;
            }
        }
    }
}
