using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;

        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: /product - 獲取所有商品
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                var products = await _context.Products.Find(p => true).ToListAsync();
                _logger.LogInformation($"從 MongoDB 獲取到 {products.Count()} 個產品");
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "獲取產品時發生錯誤");
                return StatusCode(500, "獲取產品時發生內部錯誤");
            }
        }

        // GET: /product/{id} - 獲取單一商品
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
                var product = await _context.Products.Find(filter).FirstOrDefaultAsync();

                if (product == null)
                {
                    _logger.LogWarning($"找不到商品 ID: {id}");
                    return NotFound($"找不到商品 ID: {id}");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"獲取商品詳情時發生錯誤，ID: {id}");
                return StatusCode(500, "獲取商品詳情時發生內部錯誤");
            }
        }

        // POST: /product - 新增商品
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("商品資料不能為空");
                }

                // 驗證必填欄位
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return BadRequest("商品名稱為必填");
                }

                // MongoDB 會自動生成 Id，所以這裡設為 null
                product.Id = null;

                await _context.Products.InsertOneAsync(product);
                _logger.LogInformation($"成功新增商品: {product.Name}，ID: {product.Id}");

                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "新增商品時發生錯誤");
                return StatusCode(500, "新增商品時發生內部錯誤");
            }
        }

        // PUT: /product - 更新商品
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Product product)
        {
            try
            {
                if (product == null || string.IsNullOrWhiteSpace(product.Id))
                {
                    return BadRequest("商品資料或 ID 不能為空");
                }

                // 驗證必填欄位
                if (string.IsNullOrWhiteSpace(product.Name))
                {
                    return BadRequest("商品名稱為必填");
                }

                var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
                var existingProduct = await _context.Products.Find(filter).FirstOrDefaultAsync();

                if (existingProduct == null)
                {
                    _logger.LogWarning($"找不到要更新的商品 ID: {product.Id}");
                    return NotFound($"找不到商品 ID: {product.Id}");
                }

                var result = await _context.Products.ReplaceOneAsync(filter, product);

                if (result.IsAcknowledged && result.ModifiedCount > 0)
                {
                    _logger.LogInformation($"成功更新商品: {product.Name}，ID: {product.Id}");
                    return Ok(product);
                }

                return StatusCode(500, "更新商品失敗");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新商品時發生錯誤");
                return StatusCode(500, "更新商品時發生內部錯誤");
            }
        }

        // DELETE: /product/{id} - 刪除商品
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return BadRequest("商品 ID 不能為空");
                }

                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
                var result = await _context.Products.DeleteOneAsync(filter);

                if (result.DeletedCount == 0)
                {
                    _logger.LogWarning($"找不到要刪除的商品 ID: {id}");
                    return NotFound($"找不到商品 ID: {id}");
                }

                _logger.LogInformation($"成功刪除商品 ID: {id}");
                return Ok(new { message = "商品刪除成功", id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"刪除商品時發生錯誤，ID: {id}");
                return StatusCode(500, "刪除商品時發生內部錯誤");
            }
        }
    }
}
