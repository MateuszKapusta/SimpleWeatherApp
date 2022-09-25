using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SimpleWeatherApp.Core.Models.Weather.Dtos
{
    public class WeatherDetailDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
