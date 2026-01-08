using CabinetVeterinarMobile.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using CabinetVeterinarMobile.Views;

namespace CabinetVeterinarMobile
{
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
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "vet.db3");
            builder.Services.AddSingleton(new VetDatabase(dbPath));

            builder.Services.AddSingleton<PetsPage>();

            return builder.Build();
        }
    }
}
