using Microsoft.AspNetCore.Mvc;
using WebShopMVC.Models.DTO;
using WebShopMVC.Models.Entities;
using WebShopMVC.Models.Utils;
using WebShopMVC.Models.Views;
using WebShopMVC.Services;

namespace WebShopMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetProducts();

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Product list", "Products", "Index")
            };

            return View(products);
        }

        public IActionResult GetById([FromRoute] int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            Product? product = _productService.GetProductById((int)id);

            if (product is null)
                return RedirectToAction("Index");

            ProductViewModel model = new ProductViewModel()
            {
                Product = product,
                Review = new ReviewDTO()
            };


            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Product list", "Products", "Index"),
                new BreadcrumbItem(product.Name, "Products", "GetById")
            };

            return View(model);
        }
    }
}
