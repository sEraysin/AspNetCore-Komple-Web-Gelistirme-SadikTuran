using AspNetCoreDersleri1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreDersleri1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
