using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Urun Id")]
        public int ProductId { get; set; }

        [Display(Name = "Urun Adı")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Urun Fiyat")]
        [Range(0,100000, ErrorMessage = "Lütfen 0-100000 arası sayı gir")]
        [Required]
        public decimal? Price { get; set; }
        [Display(Name = "Urun Resim")]
      
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Category")]

        [Required]
        public int? CategoryId { get; set; }

       
    }
}

