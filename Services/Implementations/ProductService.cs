using WebShopMVC.Data.Models;
using WebShopMVC.Data.Repositories;
using WebShopMVC.Data.Repositories.Implementations;

namespace WebShopMVC.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
