using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimpleWeatherApp.Core.Models.Settings.Enums;
using SimpleWeatherApp.Core.ViewModels.Main;
using SimpleWeatherApp.Core.ViewModels.Menu;
using SimpleWeatherApp.Core.ViewModels.Settings;
using SimpleWeatherApp.Core.ViewModels.Weather;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Core.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public IMvxAsyncCommand<TemperatureUnits> SelectUnitCommand { get; private set; }

        private List<TemperatureUnits> _units;

        public List<TemperatureUnits> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                RaisePropertyChanged(() => Units);
            }
        }

        public SettingsViewModel()
        {
            SelectUnitCommand = new MvxAsyncCommand<TemperatureUnits>(SelectUnitAsync);

            Units = new List<TemperatureUnits> {
                TemperatureUnits.Fahrenheit,
                TemperatureUnits.Celsius,
                TemperatureUnits.Kelvin};
        }



        private Task SelectUnitAsync(TemperatureUnits unit)
        {
            return Task.CompletedTask;
        }

    }
}


