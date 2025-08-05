using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Models.Views
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public ReviewDTO? Review { get; set; }
    }
}
