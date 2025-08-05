using WebShopMVC.Data;
using WebShopMVC.Data.Models;

namespace WebShopMVC.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _database;

        public UserService(ApplicationDbContext database)
        {
            _database = database;
        }

        public User? GetUserById(int userId)
        {
            return _database.Users.Find(userId);
        }
    }
}
