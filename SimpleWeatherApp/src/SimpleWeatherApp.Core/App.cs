using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SimpleWeatherApp.Core.ViewModels.Main;

namespace SimpleWeatherApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
