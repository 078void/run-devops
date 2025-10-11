using System.Diagnostics;
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


        public async Task<IActionResult> Index()
        {
            //return View(ProductContext.Products);
            var response = await _httpClient.GetAsync("/product");
            var content = await response.Content.ReadAsStringAsync();
            var productsList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productsList);
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
