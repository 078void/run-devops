using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Data;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // 列表頁面 - 顯示所有商品
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("/product");
                var content = await response.Content.ReadAsStringAsync();
                var productsList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
                return View(productsList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "獲取商品列表時發生錯誤");
                return View(new List<Product>());
            }
        }

        // 商品詳情頁面
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var response = await _httpClient.GetAsync($"/product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product>(content);
                    return View(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"獲取商品詳情時發生錯誤，商品ID: {id}");
                return NotFound();
            }
        }

        // GET: 新增商品頁面
        public IActionResult Create()
        {
            return View();
        }

        // POST: 新增商品
        [HttpPost]
        //[ValidateAntiForgeryToken]  // 暫時註解以解決 Docker 環境中的 token 問題
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(product);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync("/product", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "商品新增成功！";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "商品新增失敗，請稍後再試。";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "新增商品時發生錯誤");
                    TempData["ErrorMessage"] = "商品新增失敗：" + ex.Message;
                }
            }
            return View(product);
        }

        // GET: 編輯商品頁面
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var response = await _httpClient.GetAsync($"/product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product>(content);
                    return View(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"獲取商品編輯資訊時發生錯誤，商品ID: {id}");
                return NotFound();
            }
        }

        // POST: 更新商品
        [HttpPost]
        //[ValidateAntiForgeryToken]  // 暫時註解以解決 Docker 環境中的 token 問題
        public async Task<IActionResult> Edit(string id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(product);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"/product", content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["SuccessMessage"] = "商品更新成功！";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "商品更新失敗，請稍後再試。";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "更新商品時發生錯誤");
                    TempData["ErrorMessage"] = "商品更新失敗：" + ex.Message;
                }
            }
            return View(product);
        }

        // GET: 刪除確認頁面
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var response = await _httpClient.GetAsync($"/product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product>(content);
                    return View(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"獲取商品刪除資訊時發生錯誤，商品ID: {id}");
                return NotFound();
            }
        }

        // POST: 確認刪除商品
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]  // 暫時註解以解決 Docker 環境中的 token 問題
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "商品刪除成功！";
                }
                else
                {
                    TempData["ErrorMessage"] = "商品刪除失敗，請稍後再試。";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "刪除商品時發生錯誤");
                TempData["ErrorMessage"] = "商品刪除失敗：" + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
