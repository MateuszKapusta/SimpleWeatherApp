using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeatherApp.Core.Services.Rest
{
    public interface IRestService
    {
        Task<TResult> GetAsync<TResult>(string url, Dictionary<string, string> parameters = null) where TResult : new();
    }
}
