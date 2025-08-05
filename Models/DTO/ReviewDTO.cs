using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace WebShopMVC.Models.DTO
{
    public class ReviewDTO
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name")]
        [MaxLength(64, ErrorMessage = "The author's name is too long")]
        public string? Author { get; set; }

        [Display(Name = "Review text")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Write the text of the review")]
        [MaxLength(512, ErrorMessage = "The review text is too long")]
        public string? Text { get; set; }
    }
}
