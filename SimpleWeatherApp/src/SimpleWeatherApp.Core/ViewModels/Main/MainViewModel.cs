using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SimpleWeatherApp.Core.Infrastructure;
using SimpleWeatherApp.Core.Models.Menu.Dtos;
using SimpleWeatherApp.Core.Models.Weather.Dtos;
using SimpleWeatherApp.Core.Services.Configuration;
using SimpleWeatherApp.Core.Services.Rest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public IMvxAsyncCommand NewCityNameCommand { get; private set; }
        public IMvxAsyncCommand<CountryInfoDto> SelectCityCommand { get; private set; }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set
            {
                _cityName = value;
                RaisePropertyChanged(() => CityName);
            }
        }

        private ObservableCollection<CountryInfoDto> _countryInfo;
        public ObservableCollection<CountryInfoDto> CountryInfo
        {
            get { return _countryInfo; }
            set
            {
                _countryInfo = value;
                RaisePropertyChanged(() => CountryInfo);
            }
        }

        private readonly IRestService restService;
        private readonly IMvxNavigationService navigationService;
        private readonly IConfigurationService configurationService;

        public MainViewModel(IRestService restService
            , IMvxNavigationService navigationService
            , IConfigurationService configurationService)
        {
            this.restService = restService;
            this.navigationService = navigationService;
            this.configurationService = configurationService;

            NewCityNameCommand = new MvxAsyncCommand(NewCityNameAsync);
            SelectCityCommand = new MvxAsyncCommand<CountryInfoDto>(SelectCityAsync);
        }

        public override Task Initialize()
        {
            if(!string.IsNullOrEmpty(configurationService.FavoritePlaceName))
            {
                _cityName = configurationService.FavoritePlaceName;
            }

            return base.Initialize();
        }



        private async Task NewCityNameAsync()
        {
            var parameters = new Dictionary<string, string>()
            {
                { "q", CityName },
                { "limit", "0" }
            };

            try
            {
                var cityData = await restService.GetAsync<List<CountryInfoDto>>(Endpoints.DirectionData, parameters);
                CountryInfo = new ObservableCollection<CountryInfoDto>(cityData);
            }
            catch(Exception ex)
            {
                //TODO: Add pop-up error message
            }
        }
        private async Task SelectCityAsync(CountryInfoDto city)
        {
            await navigationService.Navigate<MainDialogViewModel, CoordDto>(new CoordDto() {Latitude = city.Lat, Longitude = city.Lon });
        }

    }
}


