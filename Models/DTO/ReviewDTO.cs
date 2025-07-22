using System.ComponentModel.DataAnnotations;

namespace WebShopMVC.Models.DTO
{
    public class ReviewDTO
    {
        public int? ProductId { get; set; }
        [Display(Name = "Your Name")]
        public string? Author { get; set; }
        [Display(Name = "Your Review")]
        [DataType(DataType.MultilineText)]
        public  string? Text { get; set; }
    }
}
