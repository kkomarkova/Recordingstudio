using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HQrecordingstudioBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;

namespace HQrecordingstudioBlazor.Client.ViewModel 
{ 
    [AllowAnonymous]
    public class CatalogueViewModel
    {
        public Action StateHasChangedDelegate { get; set; }
        public List<CatalogueItem> CatalogueItems { get; set; }
        public CatalogueItem SelectedItem { get; set; }

        public readonly HttpClient _http;
        public readonly IHttpClientFactory _httpClientFactory;

        public CatalogueViewModel(
            IHttpClientFactory HttpClientFactory) {
            _httpClientFactory = HttpClientFactory;
            _http = _httpClientFactory.CreateClient("HQrecordingstudioBlazor.Public");
        }

        public async Task PopulateCatalogue() {
            
            try
            {
                CatalogueItems = await _http.GetFromJsonAsync<List<HQrecordingstudioBlazor.Shared.Models.CatalogueItem>>("api/catalogue");
            }
            catch (Exception ex) {
                
            }
            
        }

        public async Task SelectTrack(int Id)
        {

            try
            {
                SelectedItem = await _http.GetFromJsonAsync<HQrecordingstudioBlazor.Shared.Models.CatalogueItem>($"api/catalogue/{Id}");
                StateHasChangedDelegate.Invoke();
            }
            catch (Exception ex)
            {

            }

        }
       
    }
}
