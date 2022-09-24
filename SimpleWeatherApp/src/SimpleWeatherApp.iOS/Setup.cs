using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using SimpleWeatherApp.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace SimpleWeatherApp.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.NSLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override IMvxIosViewPresenter CreateViewPresenter()
            => new MvxSidebarPresenter(ApplicationDelegate, Window);
    }
}
