using Microsoft.Extensions.Logging;
using MoveToRegionException.Views;
using MoveToRegionException.ViewModels;
using MoveToRegionException.Services;

namespace MoveToRegionException;

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
			})
			.UseMauiMaps();

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<DataService>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<MapPage>();
        builder.Services.AddTransient<MapPageViewModel>();

        return builder.Build();
	}
}

