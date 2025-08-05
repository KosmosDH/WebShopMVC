using Microsoft.AspNetCore.Mvc.Filters;
using WebShopMVC.Data.Models;
using WebShopMVC.Services;

namespace WebShopMVC.Filters
{
    public class CurrentUserFilter : IActionFilter
    {
        private readonly IUserService _userService;

        public CurrentUserFilter(IUserService userService)
        {
            _userService = userService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ISession session = context.HttpContext.Session;
            int? userId = session.GetInt32("User.Id");

            if (userId == null)
                return;

            User? user = _userService.GetUserById((int) userId);

            if (user == null)
                return;

            context.HttpContext.Items["CurrentUser"] = user;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
