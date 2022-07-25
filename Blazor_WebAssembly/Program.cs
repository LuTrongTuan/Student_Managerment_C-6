using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor_WebAssembly.IServices;
using Blazor_WebAssembly.Services;

namespace Blazor_WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });
            builder.Services.AddTransient<ISchoolApiClient, SchoolApiClient>();

            await builder.Build().RunAsync();
        }
    }
}
