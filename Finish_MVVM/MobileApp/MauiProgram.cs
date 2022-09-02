﻿using MobileApp.Services;
using MobileApp.ViewModels;
using MobileApp.Views;

namespace MobileApp;

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

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<DetailsPage>();
        builder.Services.AddSingleton<DetailsViewModel>();
        builder.Services.AddSingleton<IWeatherService, WeatherService>();

        return builder.Build();
    }
}
