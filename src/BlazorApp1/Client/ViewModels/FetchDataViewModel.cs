using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp1.Client.Models;
using BlazorApp1.Shared;
using LogoFX.Client.Mvvm.ViewModel;

namespace BlazorApp1.Client.ViewModels
{
    public interface IFetchDataViewModel
    {
        IEnumerable WeatherForecasts { get; }
        IEnumerable<WeatherForecast> TypedWeatherForecasts { get; }
        Task RetrieveForecastsAsync();
    }

    public class FetchDataViewModel : IFetchDataViewModel
    {
        private readonly IFetchDataService _fetchDataService;

        public FetchDataViewModel(IFetchDataService fetchDataService)
        {
            _fetchDataService = fetchDataService;
        }

        private WrappingCollection _weatherForecasts;
        public IEnumerable WeatherForecasts => _weatherForecasts ??= CreateWeatherForecasts();
        IEnumerable<WeatherForecast> IFetchDataViewModel.TypedWeatherForecasts => WeatherForecasts.OfType<WeatherForecast>();

        private WrappingCollection CreateWeatherForecasts()
        {
            var wc = new WrappingCollection(
                )
                {
            FactoryMethod = r => r};
            wc.AddSource(_fetchDataService.WeatherForecasts);
            return wc;
        }

        public async Task RetrieveForecastsAsync()
        {
            await _fetchDataService.RetrieveForecastsAsync();
        }
    }
}
