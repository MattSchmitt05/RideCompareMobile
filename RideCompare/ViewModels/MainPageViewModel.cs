using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using RideCompare.Models;
using RideCompare.Services.Deeplinking;
using RideCompare.Services.Dialog;
using RideCompare.Services.Locale;
using RideCompare.Services.RideCompare;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace RideCompare.ViewModels
{
    internal sealed class MainPageViewModel : ViewModelBase
    {
        public static double Distance { get; set; }

        private bool _isButtonEnabled;
        public bool IsButtonEnabled 
        {
            get => _isButtonEnabled;
            set { _isButtonEnabled = value; RaisePropertyChanged("IsButtonEnabled"); }
        }

        private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection 
        { 
            get => _pinCollection; 
            set { _pinCollection = value; RaisePropertyChanged("PinCollection"); } 
        }

        private Position _mapPosition;
        public Position MapPosition 
        { 
            get => _mapPosition; 
            set { _mapPosition = value; RaisePropertyChanged("MapPosition"); } 
        }

        private string _destinationAddress;
        public string DestinationAddress 
        { 
            get => _destinationAddress; 
            set { _destinationAddress = value; RaisePropertyChanged("DestinationAddress"); } 
        }

        public ICommand FocusedCommand => new Command(async () => await NavigateToLocationsPage());
        public ICommand RideCompareCommand => new Command(async () => await GetBestRide());

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters.ContainsKey("endLat") &&
                    parameters.ContainsKey("endLng") &&
                    parameters.ContainsKey("address") &&
                    parameters.ContainsKey("distance"))
                {
                    var endLat = double.Parse(parameters["endLat"].ToString());
                    var endLng = double.Parse(parameters["endLng"].ToString());
                    Distance = double.Parse(parameters["distance"].ToString());
                    MapPosition = new Position(endLat, endLng);
                    var pinCount = _pinCollection.Count;
                    if (pinCount > 1)
                        _pinCollection.RemoveAt(pinCount - 1);
                    
                    PinCollection.Add(new Pin { Position = MapPosition, Type = PinType.Generic, Label = "Destination" });
                    DestinationAddress = parameters["address"].ToString();
                    IsButtonEnabled = true;
                }
                else if (PinCollection?.Count == 0)
                {
                    var location = await GeolocationService.GetDeviceLocation();
                    MapPosition = new Position(location.Latitude, location.Longitude);
                    PinCollection.Add(new Pin { Position = MapPosition, Type = PinType.Generic, Label = "My Location" });
                    IsButtonEnabled = false;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlert("Unable to get device location");
            }
        }

        private async Task NavigateToLocationsPage()
        {
            if (PinCollection?.Count > 0)
            {
                var myLocation = PinCollection[0].Position;
                await NavigationService
                    .NavigateAsync("LocationsPage", new NavigationParameters($"startLat={myLocation.Latitude}&startLng={myLocation.Longitude}"));
            }
        }

        private async Task GetBestRide()
        {
            try
            {
                DialogService.ShowLoading();
                var rideCompareService = new RideCompareService();
                var results = await rideCompareService.GetBestRide(PinCollection);
                DialogService.HideLoading();
                await NavigateToRideshareApp(results);
            }
            catch (Exception ex)
            {
                DialogService.HideLoading();
                await DialogService.ShowAlert("Something went wrong. Unable to get a best ride. \n \n Please try again.");
            }
        }

        private async Task NavigateToRideshareApp(RideCompareResponse rideCompareResponse)
        {
            var bestRide = rideCompareResponse.BestRide;

            var startLat = PinCollection[0].Position.Latitude;
            var startLng = PinCollection[0].Position.Longitude;
            var endLat = PinCollection[1].Position.Latitude;
            var endLng = PinCollection[1].Position.Longitude;
            var deepLinkingService = new DeeplinkingService(startLat, startLng, endLat, endLng);

            switch (bestRide.RideShareProvider)
            {
                case "Lyft":
                    await DialogService.ShowAlert("Lyft is offering the Best Ride! \n We will take you to Lyft.");
                    deepLinkingService.OpenLyft();
                    break;
                case "Uber":
                    await DialogService.ShowAlert("Uber is offering the Best Ride! \n We will take you to Uber.");
                    deepLinkingService.OpenUber();
                    break;
                default:
                    await DialogService.ShowAlert("No Best Ride was found. \n We will show you what we found.");
                    await NavigationService
                        .NavigateAsync("BestRideDetailsPage", new NavigationParameters($"cost={bestRide.RideCost}" +
                                                                                       $"&costProvider={bestRide.LowestRideCostProvider}" +
                        	                                                           $"&eta={bestRide.RideEta}" +
                                                                                       $"&etaProvider={bestRide.ShortestRideEtaProvider}" +
                                                                                       $"&startLat={startLat}&startLng={startLng}" +
                                                                                       $"&endLat={endLat}&endLng={endLng}"));
                    break;
            }
        }
    }
}
