using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".webp" };
        private const long MaxImageSize = 2 * 1024 * 1024;

        public IActionResult Index(string searchString, string category)
        {
            var products = Repository.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString;
                products = products.Where(p => p.Name != null && p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!String.IsNullOrEmpty(category) && category != "0")
            {
                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }
            //    ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name",category);
            var model = new ProductViewModel
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category
            };
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name"); return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product model, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var imageName = await SaveImageAsync(imageFile);
                if (imageName == null)
                {
                    ModelState.AddModelError("Image", "Sadece jpg, jpeg, png veya webp formatinda en fazla 2 MB resim yukleyin.");
                }
                else
                {
                    model.Image = imageName;
                }
            }

            if (ModelState.IsValid)
            {
                model.ProductId = Repository.Products.Any() ? Repository.Products.Max(p => p.ProductId) + 1 : 1;
                Repository.CreateProduct(model);

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id.Value);

            if (entity == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile)
        {
            if (id != model.ProductId)
            {
                return NotFound();
            }

            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);

            if (entity == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var imageName = await SaveImageAsync(imageFile);
                    if (imageName == null)
                    {
                        ModelState.AddModelError("Image", "Sadece jpg, jpeg, png veya webp formatinda en fazla 2 MB resim yukleyin.");
                        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
                        return View(model);
                    }

                    model.Image = imageName;
                }
                else
                {
                    model.Image = entity.Image;
                }

                Repository.EditProduct(model);

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
            if (entity == null) { return NotFound(); }
            return View("DeleteConfirm", entity);
        }

        public IActionResult DeleteConfirm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int productId)
        {
            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (entity == null)
            {
                return NotFound();
            }

            Repository.DeleteProduct(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProducts(List<Product> Products)
        {
            foreach (var product in Products) 
            {
                Repository.EditIsActive(product);
            }
            return RedirectToAction("Index");
        }

        private static async Task<string?> SaveImageAsync(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!AllowedImageExtensions.Contains(extension) || imageFile.Length > MaxImageSize)
            {
                return null;
            }

            var randomFileName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", randomFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return randomFileName;
        }
    }
}
