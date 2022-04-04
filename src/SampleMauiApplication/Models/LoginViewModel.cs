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

        public bool ValidateLogin(out string jwtToken)
        {
            if(Username.Equals("Test") && Password.Equals("Test"))
            {
                jwtToken = "123456";
                return true;
            }

            //Not valid
            jwtToken = null;
            LoginFailureHidden = false;
            return false;
        }
    }
}
