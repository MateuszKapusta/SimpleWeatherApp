using SimpleWeatherApp.Core.Models.Weather.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.ViewModels.Weather
{
    public class WeatherViewModel : BaseViewModel<CoordDto>
    {
        private CoordDto _cityCord;

        public override void Prepare(CoordDto parameter)
        {
            _cityCord = parameter;
        }



    }
}
