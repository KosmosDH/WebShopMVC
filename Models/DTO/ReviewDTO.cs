using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace WebShopMVC.Models.DTO
{
    public class ReviewDTO
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Put your name")]
        [MaxLength(64, ErrorMessage = "Author name is too long")]
        public string? Author { get; set; }

        [Display(Name = "Review text")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Put text of review")]
        [MaxLength(512, ErrorMessage = "Review text is too long")]
        public string? Text { get; set; }
    }
}
