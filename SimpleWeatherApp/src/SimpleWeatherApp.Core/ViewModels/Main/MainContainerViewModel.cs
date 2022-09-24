using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimpleWeatherApp.Core.ViewModels.Menu;

namespace SimpleWeatherApp.Core.ViewModels.Main
{
    public class MainContainerViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowMenuCommand { get; private set; }

        public MainContainerViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowMenuCommand = new MvxAsyncCommand(NavigateToMenuAsync);
        }

        private Task NavigateToMenuAsync()
        {
            return _navigationService.Navigate<MenuViewModel>();
        }
    }
}
