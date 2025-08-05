using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebShopMVC.Filters
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISession session = context.HttpContext.Session;
            int? userId = session.GetInt32("User.Id");

            if (userId != null)
                return;

            context.Result = new UnauthorizedResult();
        }
    }
}
