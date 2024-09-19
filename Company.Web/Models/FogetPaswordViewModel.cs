using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class FogetPaswordViewModel
    {
        [Required(ErrorMessage = "Email  IS required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
