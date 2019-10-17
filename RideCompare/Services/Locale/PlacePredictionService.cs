using GooglePlacesApi;
using GooglePlacesApi.Models;
using RideCompare.Services.ConfigurationProvider;
using RideCompare.Services.ServiceLocator;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RideCompare.Services.Locale
{
    internal sealed class PlacePredictionService : PlacePredictionServiceBase
    {
        private ServiceLocatorBase _serviceLocator;
        private ServiceLocatorBase ServiceLocator => _serviceLocator ?? (_serviceLocator = new ServiceLocator.ServiceLocator());

        private ConfigurationProviderBase _configurationProvider;
        private ConfigurationProviderBase ConfigurationProvider => _configurationProvider ?? (_configurationProvider = ServiceLocator.CreateConfigurationProvider());

        private static string _apiKey;
        private static readonly GoogleApiSettings _settings = GoogleApiSettings.Builder
                                            .WithApiKey(_apiKey)
                                            .WithType(PlaceTypes.GeoCode)
                                            .Build();

        private static readonly GooglePlacesApiService _service = new GooglePlacesApiService(_settings);

        public PlacePredictionService()
        {
            _apiKey = ConfigurationProvider.GetPlacePredictionApiKey();
        }

        protected override async Task<ObservableCollection<string>> GetPredictionsAsyncCore(string searchText)
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
