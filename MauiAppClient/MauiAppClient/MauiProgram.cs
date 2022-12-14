using MauiAppClient.Services;
using MauiAppClient.Views;

namespace MauiAppClient;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//builder.Services.AddSingleton<IRestDataService, RestServices>();
        builder.Services.AddHttpClient<IRestDataService, RestServices>();

        builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ManageUsersPage>();

		return builder.Build();
	}
}
