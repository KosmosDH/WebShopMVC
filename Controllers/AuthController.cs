using Microsoft.AspNetCore.Mvc;
using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;
using WebShopMVC.Models.Utils;
using WebShopMVC.Services;

namespace WebShopMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Authorization", "Auth", "Authorization")
            };

            return View(new UserCredentialsDto());
        }

        [HttpPost]
        public IActionResult LogIn([FromForm] UserCredentialsDto userCredentialsDto)
        {
            if (!ModelState.IsValid)
                return View("Authorization", userCredentialsDto);

            User? user = _authService.GetUserByCredentials(userCredentialsDto);

            if (user is null)
            {
                ViewBag.ErrorMessage = "Incorrect email address or password.";
                return View("Authorization", userCredentialsDto);
            }

            ISession session = HttpContext.Session;
            session.SetInt32("User.Id", user.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.Breadcrumb = new List<BreadcrumbItem>()
            {
                new BreadcrumbItem("Registration", "Auth", "Registration")
            };

            return View(new NewUserDto());
        }

        [HttpPost]
        public IActionResult SignUp([FromForm] NewUserDto newUserDto)
        {
            if (!ModelState.IsValid)
                return View("Registration", newUserDto);

            try
            {
                _authService.CreateUser(newUserDto);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Something went wrong.";
                return View("Registration", newUserDto);
            }

            return RedirectToAction("Authorization");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            User? user = (User?) HttpContext.Items["CurrentUser"];

            if (user == null)
                return RedirectToAction("Index", "Home");

            ISession session = HttpContext.Session;
            session.Remove("User.Id");

            return RedirectToAction("Index", "Home");
        }
    }
}
