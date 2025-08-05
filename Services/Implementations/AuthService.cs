using System.Security.Cryptography;
using System.Text;
using WebShopMVC.Data;
using WebShopMVC.Data.Models;
using WebShopMVC.Models.DTO;

namespace WebShopMVC.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _database;

        public AuthService(ApplicationDbContext database)
        {
            _database = database;
        }

        private string HashWithSha256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(textBytes);

                StringBuilder builder = new StringBuilder();

                foreach (byte hashByte in hashBytes)
                    builder.Append(hashByte.ToString("x2"));

                return builder.ToString();
            }
        }

        public User? GetUserByCredentials(UserCredentialsDto userCredentialsDto)
        {
            string email = userCredentialsDto.Email;
            string hashedPassword = HashWithSha256(userCredentialsDto.Password);

            return _database.Users.Where(u => u.Email == email && u.Password == hashedPassword)
                                  .FirstOrDefault();
        }

        public void CreateUser(NewUserDto newUserDto)
        {
            User user = new User()
            {
                FirstName = newUserDto.FirstName,
                LastName = newUserDto.LastName,
                Email = newUserDto.Email,
                Password = HashWithSha256(newUserDto.Password)
            };

            _database.Users.Add(user);
            _database.SaveChanges();
        }
    }
}
