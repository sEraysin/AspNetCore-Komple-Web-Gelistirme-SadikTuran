using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoreApp.Data.Concrete;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Web.Models
{
    public class OrderModel
    {

        public int Id { get; set; }
        public DateTime OrderData { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Phone { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string AdreesLine { get; set; } = null!;
        [BindNever]
        public Cart? Cart { get; set; } = null!;
        public string? CartName { get; set; }
        public string? CartNumber { get; set; }
        public string? ExpirationMonth { get; set; }
        public string? ExpirationYear { get; set; }
        public string? Cvc { get; set; }
    }
}
