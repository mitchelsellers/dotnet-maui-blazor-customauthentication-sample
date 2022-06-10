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

        public async Task<bool> ValidateLoginAsync(out string jwtToken)
        {
            try
            {
                WebAuthenticatorResult authResult = await WebAuthenticator.Default.AuthenticateAsync(
                    new WebAuthenticatorOptions()
                    {
                        Url = new Uri("https://mysite.com/mobileauth/Microsoft"),
                        CallbackUrl = new Uri("myapp://"),
                        PrefersEphemeralWebBrowserSession = true
                    });

                string accessToken = authResult?.AccessToken;

                // Do something with the token
            }
            catch (TaskCanceledException e)
            {
                // Use stopped auth
            }


            if (Username.Equals("Test") && Password.Equals("Test"))
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
