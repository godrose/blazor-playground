using System.Threading.Tasks;
using BlazorApp1.Client.Models;
using BlazorApp1.Client.ViewModels;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddTransient<IFetchDataViewModel, FetchDataViewModel>();
            builder.Services.AddTransient<IFetchDataService, FetchDataService>();

            await builder.Build().RunAsync();
        }
    }
}
