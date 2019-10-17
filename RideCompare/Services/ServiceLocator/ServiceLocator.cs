using System;
using System.Collections.Generic;
using System.Text;
using RideCompare.Services.Deeplinking;
using RideCompare.Services.Dialog;
using RideCompare.Services.DistanceCalculation;
using RideCompare.Services.Locale;
using RideCompare.Services.Navigation;
using RideCompare.Services.RideCompare;

namespace RideCompare.Services.ServiceLocator
{
    internal sealed class ServiceLocator : ServiceLocatorBase
    {
        protected override DeeplinkingServiceBase CreateDeeplinkingServiceCore() => new DeeplinkingService();

        protected override DialogServiceBase CreateDialogServiceCore() => new DialogService();

        protected override DistanceCalculationServiceBase CreateDistanceCalculationServiceCore() => new DistanceCalculationService();

        protected override GeocodingServiceBase CreateGeocodingServiceCore() => new GeocodingService();

        protected override GeolocationServiceBase CreateGeolocationServiceCore() => new GeolocationService();

        protected override PlacePredictionServiceBase CreatePlacePredictionServiceCore() => new PlacePredictionService();

        protected override ViewNavigationServiceBase CreateViewNavigationServiceCore(IViewNavigationService navigationService) => new ViewNavigationService(navigationService);

        protected override RideCompareServiceBase CreateRideCompareServiceCore() => new RideCompareService();
    }
}
