using System.ComponentModel.DataAnnotations;

namespace ASP.NETFinalExamsProject.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
