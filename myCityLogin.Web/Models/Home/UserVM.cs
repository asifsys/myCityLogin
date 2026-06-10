using System.ComponentModel.DataAnnotations;

namespace myCityLogin.Web.Models.Home
{
    public class UserVM
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}


