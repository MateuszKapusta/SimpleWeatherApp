using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.Models.Weather.Dtos
{
    public class CoordDto
    {
        [JsonProperty("Lon")]
        public double Longitude { get; set; }

        [JsonProperty("Lat")]
        public double Latitude { get; set; }
    }
}
