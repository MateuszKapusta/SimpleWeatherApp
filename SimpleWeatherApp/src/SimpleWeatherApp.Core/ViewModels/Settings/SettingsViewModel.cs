using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimpleWeatherApp.Core.Models.Settings.Enums;
using SimpleWeatherApp.Core.Services.Configuration;
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
        public IMvxCommand<TemperatureUnits> SelectUnitCommand { get; private set; }

        private TemperatureUnits _selectUnits;

        public TemperatureUnits SelectUnits
        {
            get { return _selectUnits; }
            set
            {
                _selectUnits = value;
                RaisePropertyChanged(() => SelectUnits);
            }
        }

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

        private readonly IConfigurationService configurationService;

        public SettingsViewModel(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;

            SelectUnitCommand = new MvxCommand<TemperatureUnits>(SelectUnit);
            SelectUnits = configurationService.PreferredUnits;

            Units = new List<TemperatureUnits> {
                TemperatureUnits.metric,
                TemperatureUnits.standard,
                TemperatureUnits.imperial};
        }



        private void SelectUnit(TemperatureUnits unit)
        {
            if (unit != configurationService.PreferredUnits) 
            {
                configurationService.PreferredUnits = unit;
            }
        }

    }
}


