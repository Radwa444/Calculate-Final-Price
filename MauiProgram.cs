using calculate_final_price.Domain.User_Cases;
using calculate_final_price.Presentation.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace calculate_final_price
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterViewModels()
                .RegisterServices()
                .RegisterPages()
                .RegisterUserCases()

                ;

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<CalculatePriceViewModel>();
            return mauiAppBuilder;
        }
        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            return mauiAppBuilder;
        }
        private static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            return mauiAppBuilder;
        }
        
        private static MauiAppBuilder RegisterUserCases(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<CalculatePriceUseCase >();
            return mauiAppBuilder;
        }
    }
}
