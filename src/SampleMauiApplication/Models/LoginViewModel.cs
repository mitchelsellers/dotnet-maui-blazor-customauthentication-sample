using System.ComponentModel.DataAnnotations;

namespace SampleMauiApplication.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool LoginFailureHidden { get; set; } = true;

        public async Task<string> ValidateLoginAsync()
        {

            if (Username.Equals("Test") && Password.Equals("Test"))
            {
                return "123456";
            }

            //Not valid
            LoginFailureHidden = false;
            return null;
        }
    }
}
