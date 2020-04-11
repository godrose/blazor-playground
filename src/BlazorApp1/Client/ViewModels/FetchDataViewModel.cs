using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp1.Client.Models;
using BlazorApp1.Shared;
using LogoFX.Core;

namespace BlazorApp1.Client.ViewModels
{
    public interface IFetchDataViewModel
    {
        IEnumerable<WeatherForecast> WeatherForecasts { get; }
        Task RetrieveForecastsAsync();
    }

    public class FetchDataViewModel : IFetchDataViewModel
    {
        private readonly IFetchDataService _fetchDataService;

        public FetchDataViewModel(IFetchDataService fetchDataService)
        {
            Console.WriteLine("FetchDataViewModel Constructor Executing");
            _fetchDataService = fetchDataService;
        }

        private readonly RangeObservableCollection<WeatherForecast> _weatherForecasts = new RangeObservableCollection<WeatherForecast>();
        public IEnumerable<WeatherForecast> WeatherForecasts => _weatherForecasts;

        public async Task RetrieveForecastsAsync()
        {
            var weatherForecasts = await _fetchDataService.RetrieveForecastsAsync();
            _weatherForecasts.Clear();
            _weatherForecasts.AddRange(weatherForecasts);
            Console.WriteLine("FetchDataViewModel Forecasts Retrieved");
        }
    }
}
