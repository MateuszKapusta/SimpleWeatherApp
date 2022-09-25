using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using SimpleWeatherApp.Core.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleWeatherApp.Core.Services.Rest
{
    public class RestService : IRestService
    {
        private JsonSerializerSettings DefaultSettings { get; set; } = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DefaultValueHandling = DefaultValueHandling.Include,
            TypeNameHandling = TypeNameHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Newtonsoft.Json.Formatting.None,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };


        private readonly IConfigurationService configurationService;

        public RestService(IConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }


        public async Task<TResult> GetAsync<TResult>(string url, Dictionary<string, string> parameters = null) where TResult : new()
        {
            using (var client = GetClient(url))
            {
                var request = new RestRequest();
                request.RequestFormat = DataFormat.Json;
                request.Method = Method.Get;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        request.AddParameter(parameter.Key, parameter.Value);
                    }
                }

                var response = await client.ExecuteGetAsync<TResult>(request);
                switch (response.StatusCode) 
                {
                    case HttpStatusCode.OK:
                        return response.Data;
                    case HttpStatusCode.NoContent:
                    case HttpStatusCode.NotFound:
                        return new TResult();
                    case HttpStatusCode.BadRequest:
                        //TODO: Add better error handling for GetAsync metod
                        //JObject jsonMessage = JObject.Parse(response.Content);
                        //throw new Exception(jsonMessage["message"].ToString());
                        throw new Exception(response.Content);
                    default:
                        throw new Exception(response.ErrorMessage);

                }
            }
        }




        private RestClient GetClient(string url)
        {
            var client = new RestClient(url);
            client.UseNewtonsoftJson(DefaultSettings);

            if(string.IsNullOrEmpty( configurationService.WeatherApiKey ))
            {
                throw new Exception("The weather api key isn't set");
            }

            client.AddDefaultParameter("appid", configurationService.WeatherApiKey);
            return client;
        }

    }
}
