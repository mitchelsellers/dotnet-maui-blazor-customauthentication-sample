using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui;
using Microsoft.Maui.Authentication;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace SampleMauiApplication.Services
{
    //From this example: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/communication/authentication?tabs=android
    public class AuthenticatingService
    {
        public string authenticationUrl { get; set; }
        public AuthenticatingService(string APIUrl)
        {
            //points to an api controller like this one: https://github.com/dotnet/maui/blob/main/src/Essentials/samples/Sample.Server.WebAuthenticator/Controllers/MobileAuthController.cs
            authenticationUrl = APIUrl + "mobileauth/";
        }

        public async Task<string> OnAuthenticate(string scheme)
        {
            try
            {
                WebAuthenticatorResult r = null;

                if (scheme.Equals("Apple", StringComparison.Ordinal)
                    && DeviceInfo.Platform == DevicePlatform.iOS
                    && DeviceInfo.Version.Major >= 13)
                {
                    // Make sure to enable Apple Sign In in both the
                    // entitlements and the provisioning profile.
                    var options = new AppleSignInAuthenticator.Options
                    {
                        IncludeEmailScope = true,
                        IncludeFullNameScope = true,
                    };
                    r = await AppleSignInAuthenticator.AuthenticateAsync(options);
                }
                else
                {
                    var authUrl = new Uri(authenticationUrl + scheme);
                    var callbackUrl = new Uri("myapp://");

                    r = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
                }

                var authToken = string.Empty;
                if (r.Properties.TryGetValue("name", out var name) && !string.IsNullOrEmpty(name))
                    authToken += $"Name: {name}{Environment.NewLine}";
                if (r.Properties.TryGetValue("email", out var email) && !string.IsNullOrEmpty(email))
                    authToken += $"Email: {email}{Environment.NewLine}";
                authToken += r?.AccessToken ?? r?.IdToken;

                return authToken;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Login canceled.");
                return string.Empty;
                //ToDo - handle fail
                //await DisplayAlertAsync("Login canceled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed: {ex.Message}");
                return string.Empty;
                //ToDo - handle fail
                //await DisplayAlertAsync($"Failed: {ex.Message}");
            }
        }
    }
}
