using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RideCompare.Helpers;
using RideCompare.Models;
using Xamarin.Forms.GoogleMaps;

namespace RideCompare.Services.RideCompare
{
    internal sealed class RideCompareService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress = Settings.RideCompareBaseAddress;

        public RideCompareService()
        {
            _httpClient = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("RideCompareClient", "1.0"));
            return httpClient;
        }

        public async Task<RideCompareResponse> GetBestRide(ObservableCollection<Pin> locations)
        {
            var httpContent = GetHttpContent(locations);
            var httpResponse = await _httpClient.PostAsync(_baseAddress + "/api/ridecompare", httpContent);
            var httpContentString = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RideCompareResponse>(httpContentString);
        }

        private HttpContent GetHttpContent(ObservableCollection<Pin> locations)
        {
            var start = locations[0].Position;
            var destination = locations[1].Position;

            var request = new RideCompareRequest
            {
                StartingLocation = new RideCompareRequest.RideCompareLocation
                {
                    Latitude = start.Latitude.ToString(),
                    Longitude = start.Longitude.ToString()
                },
                DestinationLocation = new RideCompareRequest.RideCompareLocation
                {
                    Latitude = destination.Latitude.ToString(),
                    Longitude = destination.Longitude.ToString()
                }
            };

            var requestJson = JsonConvert.SerializeObject(request);
            return new StringContent(requestJson, Encoding.UTF8, "application/json");
        }
    }
}
