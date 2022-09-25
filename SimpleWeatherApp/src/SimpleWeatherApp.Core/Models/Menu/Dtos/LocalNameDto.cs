using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SimpleWeatherApp.Core.Models.Menu.Dtos
{
    public class LocalNameDto
    {
        public string Af { get; set; }
        public string Ar { get; set; }
        public string Ascii { get; set; }
        public string Az { get; set; }
        public string Bg { get; set; }
        public string Ca { get; set; }
        public string Da { get; set; }
        public string De { get; set; }
        public string El { get; set; }
        public string En { get; set; }
        public string Eu { get; set; }
        public string Fa { get; set; }
        [JsonProperty("feature_name")]
        public string FeatureName { get; set; }
        public string Fi{ get; set; }
        public string Fr { get; set; }
        public string Gl { get; set; }
        public string He { get; set; }
        public string Hi { get; set; }
        public string Hr { get; set; }
        public string Hu { get; set; }
        public string Id { get; set; }
        public string It { get; set; }
        public string Ja { get; set; }
        public string La { get; set; }
        public string Lt { get; set; }
        public string Mk { get; set; }
        public string Nl { get; set; }
        public string No { get; set; }
        public string Pl { get; set; }
        public string Pt { get; set; }
        public string Ro { get; set; }
        public string Ru { get; set; }
        public string Sk { get; set; }
        public string Sl { get; set; }
        public string Sr { get; set; }
        public string Th { get; set; }
        public string Tr { get; set; }
        public string Vi { get; set; }
        public string Zu { get; set; }
    }
}
