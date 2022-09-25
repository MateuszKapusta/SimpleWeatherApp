using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SimpleWeatherApp.Core.Models.Weather.Dtos
{
    public class WeatherDetailShortDto
    {
        [JsonProperty("weather")]
        public IEnumerable<WeatherDto> WeatherData { get; set; }

        [JsonProperty("main")]
        public WeatherMainDto MainData { get; set; }

        public string Name { get; set; }
        public long Id { get; set; }

    }
}
