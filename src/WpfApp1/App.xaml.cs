using Microsoft.Extensions.Hosting;
using HotReload;
using SkiaSharp.WPF;
using System.Windows;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup (e);
            var builder = Host.CreateApplicationBuilder ();
            builder.Services.AddHotReload<SkiaHotReloadHandler> ();

            new MainWindow ().Show ();
        }
    }
}
