using DigimonCardApp.View;

namespace DigimonCardApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddSingleton<DigimonService>();

		builder.Services.AddSingleton<DigimonViewModel>();
		builder.Services.AddTransient<DigimonDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
