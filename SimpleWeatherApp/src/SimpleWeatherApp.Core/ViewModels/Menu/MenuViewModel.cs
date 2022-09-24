using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimpleWeatherApp.Core.ViewModels.Main;
using SimpleWeatherApp.Core.ViewModels.Settings;
using SimpleWeatherApp.Core.ViewModels.Weather;

namespace SimpleWeatherApp.Core.ViewModels.Menu
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowHomeCommand { get; private set; }
        public IMvxAsyncCommand ShowSettingsCommand { get; private set; }
        public IMvxAsyncCommand ShowWeatherCommand { get; private set; }

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowHomeCommand = new MvxAsyncCommand(NavigateToHomeAsync);
            ShowSettingsCommand = new MvxAsyncCommand(NavigateToSettingsAsync);
            ShowWeatherCommand = new MvxAsyncCommand(NavigateToWeathersAsync);
        }

        private Task NavigateToHomeAsync()
        {
            return _navigationService.Navigate<MainViewModel>();
        }

        private Task NavigateToSettingsAsync()
        {
            return _navigationService.Navigate<SettingsViewModel>();
        }

        private Task NavigateToWeathersAsync()
        {
            return _navigationService.Navigate<WeatherViewModel>();
        }
    }
}
