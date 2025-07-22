using WebShopMVC.Models.Entities;

namespace WebShopMVC.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Black bread", Description = "Black bread", Price=30},
                new Product() {Id = 2, Name = "White bread", Description = "White bread", Price=50},
                new Product() {Id = 3, Name = "Ice cream", Price=60},
                new Product() {Id = 4, Name = "Juice", Description = "Apple Juice", Price=60},
            };

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            foreach (Product product in _products)
                if (product.Id == id)
                    return product;
            return null;
        }

    }
}
