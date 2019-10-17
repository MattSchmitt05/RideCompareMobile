using RideCompare.Services.ConfigurationProvider;
using RideCompare.Services.Deeplinking;
using RideCompare.Services.Dialog;
using RideCompare.Services.DistanceCalculation;
using RideCompare.Services.Locale;
using RideCompare.Services.Navigation;
using RideCompare.Services.RideCompare;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideCompare.Services.ServiceLocator
{
    internal abstract class ServiceLocatorBase
    {
        public ConfigurationProviderBase CreateConfigurationProvider() => CreateConfigurationProviderCore();
        public DeeplinkingServiceBase CreateDeeplinkingService() => CreateDeeplinkingServiceCore();
        public DialogServiceBase CreateDialogService() => CreateDialogServiceCore();
        public DistanceCalculationServiceBase CreateDistanceCalculationService() => CreateDistanceCalculationServiceCore();
        public GeocodingServiceBase CreateGeocodingService() => CreateGeocodingServiceCore();
        public GeolocationServiceBase CreateGeolocationService() => CreateGeolocationServiceCore();
        public PlacePredictionServiceBase CreatePlacePredictionService() => CreatePlacePredictionServiceCore();
        public ViewNavigationServiceBase CreateViewNavigationService(IViewNavigationService navigationService) => CreateViewNavigationServiceCore(navigationService);
        public RideCompareServiceBase CreateRideCompareService() => CreateRideCompareServiceCore();

        protected abstract ConfigurationProviderBase CreateConfigurationProviderCore();
        protected abstract DeeplinkingServiceBase CreateDeeplinkingServiceCore();
        protected abstract DialogServiceBase CreateDialogServiceCore();
        protected abstract DistanceCalculationServiceBase CreateDistanceCalculationServiceCore();
        protected abstract GeocodingServiceBase CreateGeocodingServiceCore();
        protected abstract GeolocationServiceBase CreateGeolocationServiceCore();
        protected abstract PlacePredictionServiceBase CreatePlacePredictionServiceCore();
        protected abstract ViewNavigationServiceBase CreateViewNavigationServiceCore(IViewNavigationService navigationService);
        protected abstract RideCompareServiceBase CreateRideCompareServiceCore();
    }
}
