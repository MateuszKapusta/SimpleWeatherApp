using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.Models.Weather.Dtos
{
    public class WeatherMainDto
    {
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }
}