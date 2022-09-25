using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SimpleWeatherApp.Core.Models.Menu.Dtos
{
    public class CountryInfoDto
    {
        public string Name{ get;set;}

        [JsonProperty("local_names")]
        public LocalNameDto LocalNames { get;set;}
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

    }
}
