using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using RideCompare.Services.Dialog;
using RideCompare.Services.Locale;
using Xamarin.Forms;
using Xamarin.Essentials;
using Prism.Navigation;

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

        public ICommand TextChangedCommand => new Command<string>(async (text) => await GetPlacePredictions(text));
        public ICommand SelectedItemCommand => new Command<string>(async (text) => await GetSelectedPlace(text));

        public LocationsPageViewModel(INavigationService navigationService)
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
                    Places = await PlacePredictionService.GetPredictions(text);
                    IsSearchResultsVisible = Places.Count > 0;
                }
                else
                {
                    Places = null;
                    IsSearchResultsVisible = false;
                    DestinationAddress = null;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlert("Something went wrong. Unable to get places.");
            }
        }

        private async Task GetSelectedPlace(string place)
        {
            try
            {
                DestinationAddress = place;
                IsSearchResultsVisible = false;

                var locations = await GeocodingService.GetLocationsFromAddress(place);
                var firstLocation = locations.FirstOrDefault();
                _selectedPlace = new Location(firstLocation.Latitude, firstLocation.Longitude); 

                CalculateDistanceApart();

                await NavigationService
                    .GoBackToRootAsync(new NavigationParameters($"endLat={_selectedPlace.Latitude}&endLng={_selectedPlace.Longitude}&address={_destinationAddress}&distance={_distance}"));
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlert("Something went wrong. Unable to get selected place.");
            }
        }

        private void CalculateDistanceApart()
        {
            _distance = Location.CalculateDistance(_startingLocation, _selectedPlace, DistanceUnits.Miles);
        }
    }
}
