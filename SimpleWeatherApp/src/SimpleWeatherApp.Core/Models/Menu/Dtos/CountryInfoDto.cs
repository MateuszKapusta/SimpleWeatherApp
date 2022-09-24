using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.Models.Menu.Dtos
{
    public class CountryInfoDto
    {
        public string Name{ get;set;}
        public LocalNameDto LocalNames { get;set;}
        public double Lat { get; set; }
        public double Lot { get; set; }
        public string Country { get; set; }

    }
}
