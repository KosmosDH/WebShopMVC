using WebShopMVC.Data;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _database;

        public ProductService(ApplicationDbContext database)
        {
            _database = database;
        }

        public IList<Product> GetProducts()
        {
            return _database.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _database.Products.Find(id);
        }
    }
}
