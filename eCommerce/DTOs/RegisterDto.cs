using System.ComponentModel.DataAnnotations;

namespace eCommerce.DTOs
{
    public class RegisterDto
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }


    }
}
