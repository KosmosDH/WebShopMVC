using WebShopMVC.Models.Entities;

namespace WebShopMVC.Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product? GetProductById(int id);
    }
}
