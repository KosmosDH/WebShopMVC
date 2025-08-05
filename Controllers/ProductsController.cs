using Microsoft.AspNetCore.Mvc;
using WebShopMVC.Data.Models;
using WebShopMVC.Filters;
using WebShopMVC.Models.DTO;
using WebShopMVC.Models.Utils;
using WebShopMVC.Models.Views;
using WebShopMVC.Services;

namespace WebShopMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductsController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Product> products = _productService.GetProducts();

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Products list", "Products", "Index")
            };

            return View(products);
        }

        [HttpGet]
        public IActionResult GetById([FromRoute] int? id)
        {
            if (id is null)
                return RedirectToAction("Index");

            Product? product = _productService.GetProductById((int) id);

            if (product is null)
                return RedirectToAction("Index");

            User? user = (User?)HttpContext.Items["CurrentUser"];
            ReviewDTO? reviewDto = null;

            if (user != null)
            {
                reviewDto = new ReviewDTO();
                reviewDto.Author = user.FirstName;

                if (user.LastName != null)
                    reviewDto.Author += $" {user.LastName}";
            }

            ProductViewModel model = new ProductViewModel()
            {
                Product = product,
                Review = reviewDto
            };

            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Products list", "Products", "Index"),
                new BreadcrumbItem(product.Name, "Products", "GetById")
            };

            return View(model);
        }

        [HttpPost]
        [AuthFilter]
        public IActionResult CreateReview([FromRoute] int? id, [FromForm] ReviewDTO review)
        {
            if (id is null)
                return RedirectToAction("Index");

            Product? product = _productService.GetProductById((int)id);

            if (product is null)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
            {
                ProductViewModel model = new ProductViewModel()
                {
                    Product = product,
                    Review = review
                };

                return View("~/Views/Products/GetById.cshtml", model);
            }

            _reviewService.CreateReview(product.Id, review);

            return RedirectToAction("GetById", new { id = product.Id });
        }
    }
}
