using System.ComponentModel.DataAnnotations;

namespace WebShopMVC.Models.DTO
{
    public class UserCredentialsDto
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Specify the email address")]
        [MaxLength(320, ErrorMessage = "Incorrect email address")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter your password")]
        [MaxLength(64, ErrorMessage = "Incorrect password")]
        public string? Password { get; set; }
    }
}
