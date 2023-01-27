using Microsoft.Extensions.Logging;
using MyMauiApp.Repositories;
using MyMauiApp.Tools;
using MyMauiApp.ViewModels;
using SQLite;

namespace MyMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterAppServices()
            .RegisterViewModels()

			.RegisterRepositories()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<TripViewModel>();
        return mauiAppBuilder;
    }

	public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddTransient<DiveSpotRepository>();
		mauiAppBuilder.Services.AddTransient<TripRepository>();
		return mauiAppBuilder;
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<DiveContext>();
		return mauiAppBuilder;
    }
}
