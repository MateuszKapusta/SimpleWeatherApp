using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWeatherApp.Core.Infrastructure
{
    public static class Endpoints
    {
        public const string WeatherApi  = "https://api.openweathermap.org/data/2.5/";
        public const string WeatherData =  WeatherApi + "weather";

        public const string GeocodingApi = "http://api.openweathermap.org/geo/1.0/";
        public const string DirectionData = GeocodingApi + "direct";
    }
}
