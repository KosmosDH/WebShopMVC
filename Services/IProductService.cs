using WebShopMVC.Data.Models;

namespace WebShopMVC.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product? GetProductById(int id);
    }
}
