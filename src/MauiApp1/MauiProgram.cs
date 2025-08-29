using Microsoft.Extensions.Logging;
using SkiaSharp.MAUI;
using HotReload;
using SkiaSharp.Views.Maui.Controls.Hosting;
namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder ();
            builder
                .UseMauiApp<App> ()
                .UseSkiaSharp ()
                .ConfigureFonts (fonts =>
                {
                    fonts.AddFont ("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont ("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddHotReload<SkiaHotReloadHandler> ();
            return builder.Build ();
        }
    }
}
