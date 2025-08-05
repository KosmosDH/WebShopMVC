using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Services
{
    public interface IAuthService
    {
        User? GetUserByCredentials(UserCredentialsDto userCredentialsDto);
        void CreateUser(NewUserDto newUserDto);
    }
}
