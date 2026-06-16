using BlogApp.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class PostCreateViweModel
    {

        public int PostId { get; set; }

        [Required]
        [Display(Name = "Baslık")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Acıklama")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "İcerik")]
        public string? Content { get; set; }


        [Required]
        [Display(Name = "Url")]
        public string? Url { get; set; }

        public bool IsActive { get; set; }
        public List<Tag> Tags { get; set; } = new();
    }
}
