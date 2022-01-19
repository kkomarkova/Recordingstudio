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
        public List<CatalogueItem> PackItems { get; set; }
        public CatalogueItem SelectedItem { get; set; }
        public CatalogueItem SelectedPack { get; set; }
        public List<SamplePack> CatalogueSamplePack { get; set; }

        public readonly HttpClient _http;
        public readonly IHttpClientFactory _httpClientFactory;

        public CatalogueViewModel(
            IHttpClientFactory HttpClientFactory)
        {
            _httpClientFactory = HttpClientFactory;
            _http = _httpClientFactory.CreateClient("HQrecordingstudioBlazor.Public");
        }

        //All tracks
        public async Task PopulateCatalogue()
        {

            try
            {
                CatalogueItems = await _http.GetFromJsonAsync<List<CatalogueItem>>("api/catalogue");
            }
            catch (Exception ex)
            {

            }

        }

        public async Task SelectTrack(int Id)
        {

            try
            {
                SelectedItem = await _http.GetFromJsonAsync<CatalogueItem>($"api/catalogue/{Id}");
                StateHasChangedDelegate.Invoke();
            }
            catch (Exception ex)
            {

            }

        }

        //Load all samplepack
        public async Task SelectSamplePack()
        {

            try
            {
                CatalogueSamplePack = await _http.GetFromJsonAsync<List<SamplePack>>($"api/collection");
                StateHasChangedDelegate.Invoke();
            }
            catch (Exception ex)
            {

            }

        }
        public async Task SelectPack(int Id)
        {

            try
            {
                SelectedPack = await _http.GetFromJsonAsync<CatalogueItem>($"api/catalogue/{Id}");
                await GetTracks(Id);
                StateHasChangedDelegate.Invoke();
            }
            catch (Exception ex)
            {

            }

        }

        //Get tracks belonging to the pack
        public async Task GetTracks(int PackId)
        {

            try
            {
                PackItems = await _http.GetFromJsonAsync<List<CatalogueItem>>($"api/pack/{PackId}");
                StateHasChangedDelegate.Invoke();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
