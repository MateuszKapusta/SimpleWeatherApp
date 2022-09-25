using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.Models.Weather.Dtos
{
    public class WeatherDto
    {
        public long Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
