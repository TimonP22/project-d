using Microsoft.Extensions.Logging;

namespace project_d
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

            string dbPath = FileAccessHelper.GetLocalFilePath("maui_sqlite.db3");
            builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<DatabaseHelper>(s, dbPath));


            return builder.Build();
        }
    }
}
