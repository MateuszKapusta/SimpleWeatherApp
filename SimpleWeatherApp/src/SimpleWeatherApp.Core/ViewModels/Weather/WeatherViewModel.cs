using RestSharp.Serializers;
using SimpleWeatherApp.Core.Infrastructure;
using SimpleWeatherApp.Core.Models.Weather.Dtos;
using SimpleWeatherApp.Core.Services.Configuration;
using SimpleWeatherApp.Core.Services.Rest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Core.ViewModels.Weather
{
    public class WeatherViewModel : BaseViewModel<CoordDto>
    {
        private CoordDto _cityCord;

        private WeatherDetailDto _weatherDetail;
        public WeatherDetailDto WeatherDetail
        {
            get{ return _weatherDetail; } 
            set
            {
                _weatherDetail = value;
                RaisePropertyChanged(() => WeatherDetail);
            }

        }

        private readonly IConfigurationService configurationService;
        private readonly IRestService restService;

        public WeatherViewModel(IConfigurationService configurationService
            , IRestService restService)
        {
            this.configurationService = configurationService;
            this.restService = restService;
        }

        public override void Prepare(CoordDto parameter)
        {
            _cityCord = parameter;
        }

        public override async Task Initialize()
        {
            if(_cityCord == null)
            {
                _cityCord = new CoordDto() { 
                    Latitude = configurationService.FavoritePlaceLat,
                    Longitude = configurationService.FavoritePlaceLon
                };
            }

            await base.Initialize();
        }
        public override void ViewAppeared()
        {
            base.ViewAppeared();

            _= CheckWeather();
        }


        private async Task CheckWeather()
        {
            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    {"lat",_cityCord.Latitude.ToString(CultureInfo.InvariantCulture) },
                    {"lon",_cityCord.Longitude.ToString(CultureInfo.InvariantCulture) },
                    {"units",configurationService.PreferredUnits.ToString() }
                };
                WeatherDetail = await restService.GetAsync<WeatherDetailDto>(Endpoints.WeatherData, parameters);
            }
            catch (Exception ex)
            {
                //TODO: Add pop-up error message
            }
        }


    }
}
