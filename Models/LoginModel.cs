using System.ComponentModel.DataAnnotations;

namespace MyMvcApiProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Enter the correct credentials")]
        public required string ErrorMessage { get; set; }
    }
}
