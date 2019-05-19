using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GooglePlacesApi;
using GooglePlacesApi.Models;

namespace RideCompare.Services.Locale
{
    internal static class PlacePredictionService
    {
        private static readonly GoogleApiSettings _settings = GoogleApiSettings.Builder
                                            .WithApiKey("")
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();

        private static readonly GooglePlacesApiService _service = new GooglePlacesApiService(_settings);

        public static async Task<ObservableCollection<string>> GetPredictions(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return new ObservableCollection<string>();

            var predictions = await _service.GetPredictionsAsync(searchText);

            var places = new ObservableCollection<string>();

            foreach (var prediction in predictions.Items)
            {
                places.Add(prediction.Description);
            }

            return places;
        }
    }
}
