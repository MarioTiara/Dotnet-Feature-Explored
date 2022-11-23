using System.ComponentModel.DataAnnotations;

namespace PesonalPhotos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please provide the email address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please provide password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
