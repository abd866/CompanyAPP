using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First Name IS required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name IS required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Email  IS required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password IS required")]

        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long, contain at least one digit, one lowercase letter, one uppercase letter, and one non-alphanumeric character.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPasword IS required")]
        [Compare(nameof(Password),ErrorMessage = "ConfirmPasword  is not match")]
        public string ConfirmPasword { get; set; }
        [Required(ErrorMessage = "IsAgree IS required")]

        public string IsAgree { get; set; }
    }
}
