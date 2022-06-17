using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebView.Maui;
using SampleMauiApplication.Data;
using SampleMauiApplication.Services;

namespace SampleMauiApplication;

public static class MauiProgram
{
    public static string APIUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5096/api/" : "https://localhost:44334/api/";
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddMauiBlazorWebView();
        //Register needed elements for authentication
        builder.Services.AddAuthorizationCore(); // This is the core functionality
		builder.Services.AddScoped<CustomAuthenticationStateProvider>(); // This is our custom provider
		//When asking for the default Microsoft one, give ours!
		builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthenticationStateProvider>());

		builder.Services.AddBlazorWebView();
		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped(_ => new AuthenticatingService(APIUrl));

        return builder.Build();
	}
}
