using AspNetCoreDersleri1.Models;
using Microsoft.AspNetCore.Mvc;
namespace AspNetCoreDersleri1.Controllers
{
    public class CourseController:Controller
    {
       
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("List","Course");
            }
            var kurs = Repository.GetById(id);
            return View(kurs);
        }
        public IActionResult List()
        {
            
            return View("List",Repository.Courses);
        }
    }
}
