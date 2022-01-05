using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using HQrecordingstudioBlazor.Shared.Models;
using HQrecordingstudioBlazor.Shared.Models.Configuration;
using HQrecordingstudioBlazor.Shared.Repository;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HQrecordingstudioBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            
            // ***   this is the HTTP Client for authenticated endpoints ****
            builder.Services.AddHttpClient("HQrecordingstudioBlazor.ServerAPI",
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // ***   this is the HTTP Client for anonymous (public) endpoints ****
            builder.Services.AddHttpClient("HQrecordingstudioBlazor.Public", client => {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("HQrecordingstudioBlazor.ServerAPI"));

            builder.Services
                  .AddBlazorise(options =>
                  {
                      options.ChangeTextOnKeyPress = true;
                  })
                  .AddBootstrapProviders();


            // We call AddApiAuthorization method to add the authentication support for the Blazor client application
            builder.Services.AddApiAuthorization()
           .AddAccountClaimsPrincipalFactory<CustomUserFactory>();                      //We use our CustomFactory class 
            
            //Adding Viewmodel reference
            builder.Services.AddScoped<ViewModel.CatalogueViewModel>();
            //Registering the Repository service
            builder.Services.AddScoped<ICatalogueRepository, CatalogueRepository>();
            //Registering the Dapper Context
            builder.Services.AddScoped<DapperContext>();
            await builder.Build().RunAsync();

            //Setting the HttpClient BaseAddress
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44325/api/") });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:53171/api/") });
        }
    }
}
