using Microsoft.Extensions.Logging;
using MyTaskMaui.ViewModels;
using MyTaskMaui.Views;

namespace MyTaskMaui;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MyTaskViewModel>();
		builder.Services.AddSingleton<MyTaskPage>();

        builder.Services.AddSingleton<TaskDetailViewModel>();
        builder.Services.AddSingleton<TaskDetailPage>();

        return builder.Build();
	}
}
