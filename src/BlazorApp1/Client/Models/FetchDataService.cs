using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Models
{
    public interface IFetchDataService
    {
        Task<WeatherForecast[]> RetrieveForecastsAsync();
    }

    public class FetchDataService : IFetchDataService
    {
        private readonly HttpClient _http;

        public FetchDataService(HttpClient http)
        {
            _http = http;
        }
        public async Task<WeatherForecast[]> RetrieveForecastsAsync()
        {
            return await _http.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
