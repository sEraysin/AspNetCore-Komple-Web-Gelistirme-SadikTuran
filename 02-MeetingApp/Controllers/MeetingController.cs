using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {

        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply(UserInfo model)
        {
            if (@ModelState.IsValid)
            {
                 Repository.CreateUser(model);

            ViewBag.UserCount = Repository.Users.Count(i => i.WillAttend == true);

            return View("Thanks", model);
            }
           else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult List()
        {
          
            return View(Repository.Users);
        }

        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}
