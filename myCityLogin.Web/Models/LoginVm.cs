using System.ComponentModel.DataAnnotations;

namespace myCityLogin.Web.Models
{
    public class LoginVm
    {
       // public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
