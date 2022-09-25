using MvvmCross;
using MvvmCross.Commands;
using SimpleWeatherApp.Core.Infrastructure;
using SimpleWeatherApp.Core.Models.Menu.Dtos;
using SimpleWeatherApp.Core.Models.Weather.Dtos;
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

        public MainViewModel(IRestService restService)
        {
            this.restService = restService;

            NewCityNameCommand = new MvxAsyncCommand(NewCityNameAsync);
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
                //TODO: Add popup showing error message
            }
        }

    }
}


