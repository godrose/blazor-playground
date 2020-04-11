using System;
using System.Threading.Tasks;
using BlazorApp1.Client.Models;
using BlazorApp1.Shared;

namespace BlazorApp1.Client.ViewModels
{
    public interface IFetchDataViewModel
    {
        WeatherForecast[] WeatherForecasts { get; set; }
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

        public WeatherForecast[] WeatherForecasts { get; set; }

        public async Task RetrieveForecastsAsync()
        {
            WeatherForecasts = await _fetchDataService.RetrieveForecastsAsync();
            Console.WriteLine("FetchDataViewModel Forecasts Retrieved");
        }
    }
}
