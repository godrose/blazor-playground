using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp1.Shared;
using LogoFX.Core;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Models
{
    public interface IFetchDataService
    {
        IEnumerable<WeatherForecast> WeatherForecasts { get; }
        Task RetrieveForecastsAsync();
    }

    public class FetchDataService : IFetchDataService
    {
        private readonly HttpClient _http;

        public FetchDataService(HttpClient http)
        {
            _http = http;
        }

        private readonly RangeObservableCollection<WeatherForecast> _weatherForecasts = new RangeObservableCollection<WeatherForecast>();
        public IEnumerable<WeatherForecast> WeatherForecasts => _weatherForecasts;

        public async Task RetrieveForecastsAsync()
        {
            var weatherForecasts = await _http.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
            _weatherForecasts.Clear();
            _weatherForecasts.AddRange(weatherForecasts);
        }
    }
}
