using CarouselViewExampleApp.Pages;
using CarouselViewExampleApp.Pages.Views;
using CarouselViewExampleApp.Resources.Localization;
using CarouselViewExampleApp.ViewModels;
using LocalizationResourceManager.Maui;
using Microsoft.Extensions.Logging;
using Sharpnado.Tabs;

namespace CarouselViewExampleApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseLocalizationResourceManager(settings =>
            {
                settings.AddResource(AppResources.ResourceManager);
                settings.RestoreLatestCulture(true);
            })
            .UseSharpnadoTabs(loggerEnable: false)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<BackgroundImageView>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        builder.Services.AddTransient<CalculateView>();
        builder.Services.AddSingleton<CalculateViewModel>();

        builder.Services.AddTransient<OverviewView>();
        builder.Services.AddSingleton<OverviewViewModel>();
        
        builder.Services.AddTransient<Help>();

        return builder.Build();
    }
}
