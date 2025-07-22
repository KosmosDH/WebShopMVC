using WebShopMVC.Models.DTO;
using WebShopMVC.Models.Entities;

namespace WebShopMVC.Models.Views
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public ReviewDTO? Review { get; set; }
    }
}
