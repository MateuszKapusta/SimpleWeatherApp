using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SimpleWeatherApp.Core.Models.Menu.Dtos
{
    public class CountryInfoDto
    {
        [JsonProperty("name")]
        public string Name{ get;set;}

        [JsonProperty("local_names")]
        public LocalNameDto LocalNames { get;set;}

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lot { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

    }
}
