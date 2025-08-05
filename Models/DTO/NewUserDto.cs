using System.ComponentModel.DataAnnotations;

namespace WebShopMVC.Models.DTO
{
    public class NewUserDto
    {
        [Required(ErrorMessage = "Enter a name")]
        [MinLength(2, ErrorMessage = "The minimum length of the name is 2 characters.")]
        [MaxLength(64, ErrorMessage = "The maximum length of a name is 64 characters.")]
        public string? FirstName { get; set; }

        [MinLength(2, ErrorMessage = "The minimum length of the last name is 2 characters.")]
        [MaxLength(64, ErrorMessage = "The maximum length of the last name is 64 characters.")]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter Email")]
        [MaxLength(320, ErrorMessage = "The email address is too long")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]
        [MinLength(8, ErrorMessage = "The minimum password length is 8 characters.")]
        [MaxLength(64, ErrorMessage = "The maximum password length is 64 characters.")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        public string? ConfirmPassword { get; set; }
    }
}
