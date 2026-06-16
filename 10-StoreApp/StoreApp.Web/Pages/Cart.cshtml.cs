using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Web.Models;
using StoreApp.Web.Helpers;

namespace StoreApp.Web.Pages
{
    public class CardModel : PageModel
    {
        private IStoreRepository _repository;

        public CardModel(IStoreRepository repository, Cart cartService)
        {
            _repository = repository;
            Cart = cartService;
        }

        public Cart? Cart { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost(int Id)
        {
            var product = _repository.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                Cart?.AddItem(product, 1);

            }
            return RedirectToPage("/cart");
        }

        public IActionResult OnPostRemove(int id)
        {
            Cart?.RemoveItem(Cart.Items.First(p => p.Product.Id == id).Product);
            return RedirectToPage("/Cart");
        }
    }
}