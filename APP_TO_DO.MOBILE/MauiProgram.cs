using Microsoft.Extensions.Logging;

namespace APP_TO_DO.MOBILE
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

            // Configuración del HttpClient para consumir la API
            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7021/");
            });

            // Registro de servicios y páginas
            builder.Services.AddSingleton<Services.RecordatorioService>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}