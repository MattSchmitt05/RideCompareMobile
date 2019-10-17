using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using RideCompare.Services.Locale;
using Xamarin.Forms;
using Xamarin.Essentials;
using Prism.Navigation;
using RideCompare.Services.Navigation;
using RideCompare.Services.DistanceCalculation;

namespace RideCompare.ViewModels
{
    internal sealed class LocationsPageViewModel : ViewModelBase
    {
        private Location _startingLocation;
        private Location _selectedPlace;
        private double _distance;

        private string _destinationAddress;
        public string DestinationAddress { get => _destinationAddress; set { _destinationAddress = value; RaisePropertyChanged("DestinationAddress"); } }

        private bool _isSearchResultsVisible;
        public bool IsSearchResultsVisible { get => _isSearchResultsVisible; set { _isSearchResultsVisible = value; RaisePropertyChanged("IsSearchResultsVisible"); } }
        
        private ObservableCollection<string> _places;
        public ObservableCollection<string> Places { get => _places; set { _places = value; RaisePropertyChanged("Places"); } }

        private DistanceCalculationServiceBase _distanceCalculationService;
        private DistanceCalculationServiceBase DistanceCalculationService => _distanceCalculationService ?? (_distanceCalculationService = ServiceLocator.CreateDistanceCalculationService());

        private GeocodingServiceBase _geocodingService;
        private GeocodingServiceBase GeocodingService => _geocodingService ?? (_geocodingService = ServiceLocator.CreateGeocodingService());

        private PlacePredictionServiceBase _placePredictionService;
        private PlacePredictionServiceBase PlacePredictionService => _placePredictionService ?? (_placePredictionService = ServiceLocator.CreatePlacePredictionService());

        public ICommand TextChangedCommand => new Command<string>(async (text) => await GetPlacePredictions(text));
        public ICommand SelectedItemCommand => new Command<string>(async (text) => await GetSelectedPlace(text));

        public LocationsPageViewModel(IViewNavigationService navigationService)
            : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("startLat") && parameters.ContainsKey("startLng"))
            {
                var startLat = double.Parse(parameters["startLat"].ToString());
                var startLng = double.Parse(parameters["startLng"].ToString());
                _startingLocation = new Location(startLat, startLng);
            }
        }

        private async Task GetPlacePredictions(string text)
        {
            try
            {
                if (DestinationAddress?.Length > 0 && text?.Length > 0)
                {
                    Places = await PlacePredictionService.GetPredictionsAsync(text);
                    IsSearchResultsVisible = Places.Count > 0;
                }
                else
                {
                    Places = null;
                    IsSearchResultsVisible = false;
                    DestinationAddress = null;
                }
            }
            catch
            {
                await DialogService.ShowAlertAsync("Something went wrong. Unable to get places.", "Best Ride", "OK");
            }
        }

        private async Task GetSelectedPlace(string place)
        {
            try
            {
                DestinationAddress = place;
                IsSearchResultsVisible = false;

                var locations = await GeocodingService.GetLocationsFromAddressAsync(place);
                var firstLocation = locations.FirstOrDefault();
                _selectedPlace = new Location(firstLocation.Latitude, firstLocation.Longitude);
                _distance = DistanceCalculationService.CalculateDistanceApart(_startingLocation, _selectedPlace, DistanceUnits.Miles);

                await ViewNavigationService.NavigateToRootPageAsync(new NavigationParameters($"endLat={_selectedPlace.Latitude}&endLng={_selectedPlace.Longitude}&address={_destinationAddress}&distance={_distance}"));
            }
            catch
            {
                await DialogService.ShowAlertAsync("Something went wrong. Unable to get selected place.", "Best Ride", "OK");
            }
        }
    }
}
