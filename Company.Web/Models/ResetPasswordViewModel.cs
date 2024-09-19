using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "password IS required")]

        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,}$",
           ErrorMessage = "Password must be at least 6 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one non-alphanumeric character.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPasword IS required")]
        [Compare(nameof(Password), ErrorMessage = "ConfirmPasword  is not match")]
        public string ConfirmPasword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
