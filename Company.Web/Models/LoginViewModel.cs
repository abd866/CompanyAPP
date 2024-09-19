using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email  IS required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password IS required")]

        public string Password { get; set; }

        public bool RemberMe { get; set; }
    }
}
