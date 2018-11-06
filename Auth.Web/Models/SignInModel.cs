using System.ComponentModel.DataAnnotations;

namespace Auth.Web.Models
{
    public class SignInModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Must enter in a valid username")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Must enter in a valid password")]
        public string Password { get; set; }
    }
}