using MvvmCross.Commands;
using MvvmCross.Navigation;
using RestSharp.Serializers;
using SimpleWeatherApp.Core.Infrastructure;
using SimpleWeatherApp.Core.Models.Menu.Dtos;
using SimpleWeatherApp.Core.Models.Weather.Dtos;
using SimpleWeatherApp.Core.Services.Configuration;
using SimpleWeatherApp.Core.Services.Rest;
using SimpleWeatherApp.Core.ViewModels.Weather;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleWeatherApp.Core.ViewModels.Main
{
    public class MainDialogViewModel : BaseViewModel<CoordDto>
    {
        private CoordDto _selectedCity;

        private WeatherDetailShortDto _weatherInfo;
        public WeatherDetailShortDto WeatherInfo
        { 
            get {  return _weatherInfo; } 
            set
            {
                _weatherInfo = value;
                RaisePropertyChanged(() => WeatherInfo);
            }
        }


        public IMvxAsyncCommand BackCommand { get; }
        public IMvxAsyncCommand SaveCoordCommand { get; }
        public IMvxAsyncCommand DetailsCommand { get; }

        private readonly IMvxNavigationService navigationService;
        private readonly IRestService restService;
        private readonly IConfigurationService configurationService;

        public MainDialogViewModel(IMvxNavigationService navigationService
            , IRestService restService
            , IConfigurationService configurationService)
        {
            this.navigationService = navigationService;
            this.restService = restService;
            this.configurationService = configurationService;   

            BackCommand = new MvxAsyncCommand(BackAsync);
            DetailsCommand = new MvxAsyncCommand(DetailsAsync);
            SaveCoordCommand = new MvxAsyncCommand(SaveAsyncCoord);
        }

        public override void Prepare(CoordDto parameter)
        {
            _selectedCity = parameter;
        }
        public override async Task Initialize()
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"lat",_selectedCity.Latitude.ToString(CultureInfo.InvariantCulture) },
                    {"lon",_selectedCity.Longitude.ToString(CultureInfo.InvariantCulture) },
                    {"units",configurationService.PreferredUnits.ToString() }
                };
                WeatherInfo = await restService.GetAsync<WeatherDetailShortDto>(Endpoints.WeatherData, parameters);
            }
            catch (Exception ex)
            {
                //TODO: Add pop-up error message
            }

            await base.Initialize();
        }




        private Task BackAsync()
        {
            return navigationService.Close(this);
        }

        private Task SaveAsyncCoord()
        {
            configurationService.FavoritePlaceLat = _selectedCity.Latitude;
            configurationService.FavoritePlaceLon = _selectedCity.Longitude;
            configurationService.FavoritePlaceName = WeatherInfo.Name;

            return navigationService.Close(this);
        }
        private Task DetailsAsync()
        {
            navigationService.Close(this);
            return navigationService.Navigate<WeatherViewModel,CoordDto>( _selectedCity);
        }

        
    }
}
