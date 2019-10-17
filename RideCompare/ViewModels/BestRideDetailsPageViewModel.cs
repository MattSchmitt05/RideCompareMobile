using System.Windows.Input;
using Prism.Navigation;
using RideCompare.Services.Deeplinking;
using RideCompare.Services.Navigation;
using Xamarin.Forms;

namespace RideCompare.ViewModels
{
    internal sealed class BestRideDetailsPageViewModel : ViewModelBase
    {
        private double _startLat;
        private double _startLng;
        private double _endLat;
        private double _endLng;
        private string _lowestCost;
        private string _shortestEta;
        private string _lowestCostProvider;
        private string _shortestEtaProvider;

        private string _lowestCostDetails;
        public string LowestCostDetails
        {
            get => _lowestCostDetails;
            set { _lowestCostDetails = value; RaisePropertyChanged("LowestCostDetails"); } 
        }

        private string _shortestEtaDetails;
        public string ShortestEtaDetails
        {
            get => _shortestEtaDetails;
            set { _shortestEtaDetails = value; RaisePropertyChanged("ShortestEtaDetails"); } 
        }

        private DeeplinkingServiceBase _deepLinkingService;
        private DeeplinkingServiceBase DeeplinkingService => _deepLinkingService ?? (_deepLinkingService = ServiceLocator.CreateDeeplinkingService());

        public ICommand OpenLyftCommand => new Command(() => OpenLyftApp());
        public ICommand OpenUberCommand => new Command(() => OpenUberApp());

        public BestRideDetailsPageViewModel(IViewNavigationService navigationService) 
            : base(navigationService)
        {

        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("cost") &&
                parameters.ContainsKey("costProvider") &&
                parameters.ContainsKey("eta") &&
                parameters.ContainsKey("etaProvider") &&
                parameters.ContainsKey("startLat") &&
                parameters.ContainsKey("startLng") &&
                parameters.ContainsKey("endLat") &&
                parameters.ContainsKey("endLng"))
            {
                var costString = parameters["cost"].ToString();
                var etaString = parameters["eta"].ToString();
                _lowestCost = GetCostAsDollarsString(costString);
                _shortestEta = GetEtaAsMinutesString(etaString);

                _lowestCostProvider = parameters["costProvider"].ToString();
                _shortestEtaProvider = parameters["etaProvider"].ToString();

                LowestCostDetails = string.Format($"Lowest est. ride cost: {_lowestCostProvider} - ${_lowestCost}");
                ShortestEtaDetails = string.Format($"Shortest est. ride eta: {_shortestEtaProvider} - {_shortestEta} mins");

                _startLat = double.Parse(parameters["startLat"].ToString());
                _startLng = double.Parse(parameters["startLng"].ToString());
                _endLat = double.Parse(parameters["endLat"].ToString());
                _endLng = double.Parse(parameters["endLng"].ToString());
            }
        }

        private string GetCostAsDollarsString(string costString)
        {
            var cost = decimal.Parse(costString) / 100M;
            return cost.ToString();
        }

        private string GetEtaAsMinutesString(string etaString)
        {
            var eta = int.Parse(etaString) / 60;
            return eta.ToString();
        }

        private void OpenLyftApp()
        {
            DeeplinkingService.OpenLyft(_startLat, _startLng, _endLat, _endLng);
        }

        private void OpenUberApp()
        {
            DeeplinkingService.OpenUber(_startLat, _startLng, _endLat, _endLng);
        }
    }
}
