using Microsoft.AspNetCore.Mvc;

namespace WebShopMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
