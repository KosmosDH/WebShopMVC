using WebShopMVC.Data.Models;

namespace WebShopMVC.Services
{
    public interface IUserService
    {
        User? GetUserById(int userId);
    }
}
