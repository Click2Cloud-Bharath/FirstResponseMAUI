using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FirstResponseMAUI.Services.Navigation;
using FirstResponseMAUI.ViewModels;
using FirstResponseMAUI.Views;

namespace FirstResponseMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("TitilliumWeb-Light.ttf", "TitilliumLight");
                fonts.AddFont("TitilliumWeb-Regular.ttf", "TitilliumRegular");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Services
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<CitiesViewModel>();
        builder.Services.AddTransient<ConfigViewModel>();
        builder.Services.AddTransient<IncidentDetailViewModel>();
        builder.Services.AddTransient<IncidentListViewModel>();
        builder.Services.AddTransient<NewTicketViewModel>();
        builder.Services.AddTransient<PowerBIViewModel>();
        builder.Services.AddTransient<ResponderListViewModel>();
        builder.Services.AddTransient<SuspectViewModel>();

        // Views
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<CitiesView>();
        builder.Services.AddTransient<NewTicketPopupView>();
        builder.Services.AddTransient<PowerBIView>();
        builder.Services.AddTransient<SuspectPopupView>();

        return builder.Build();
    }
}
