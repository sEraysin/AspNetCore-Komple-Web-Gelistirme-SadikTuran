using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewData["Selamlasma"] = saat > 12 ? "Iyi gunler" : "Gunaydin";
              int UserCount = Repository.Users.Count(i => i.WillAttend == true);
            // ViewData["UserName"] = "Era7";
            var MeetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "Istanbul Teknoloji Merkezi",
                Date = new DateTime(2026, 09, 20, 20, 0, 0),
                NumberOfPeople = UserCount
            };


            return View(MeetingInfo);
        }
    }
}
