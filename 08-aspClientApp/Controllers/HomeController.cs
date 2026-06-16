using aspClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace aspClientApp.Controllers
{
    public class HomeController : Controller
    {


        public async Task<IActionResult> Index()
        {
            var products = new List<ProductDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7234/api/products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products=JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
                }
            }

            return View(products);
        }


    }
}
