using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using WebShopMVC.Models.Utils;

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
