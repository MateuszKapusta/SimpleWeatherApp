using Foundation;
using MvvmCross.Platforms.Ios.Core;
using SimpleWeatherApp.Core;

namespace SimpleWeatherApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
