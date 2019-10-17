using RideCompare.Services.ConfigurationProvider;
using RideCompare.Services.Deeplinking;
using RideCompare.Services.Dialog;
using RideCompare.Services.DistanceCalculation;
using RideCompare.Services.Locale;
using RideCompare.Services.Navigation;
using RideCompare.Services.RideCompare;
using RideCompare.Services.ServiceLocator;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Deeplinking;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Dialog;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.DistanceCalculation;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Locale;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Navigation;
using RideCompare.Tests.AcceptanceTests.TestDoubles.Services.RideCompare;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Tests.AcceptanceTests.ServiceLocator
{
    [ExcludeFromCodeCoverage]
    internal sealed class ServiceLocatorForTest : ServiceLocatorBase
    {
        protected override ConfigurationProviderBase CreateConfigurationProviderCore() => throw new NotImplementedException();

        protected override DeeplinkingServiceBase CreateDeeplinkingServiceCore() => new DeeplinkingServiceSpy();

        protected override DialogServiceBase CreateDialogServiceCore() => new DialogServiceSpy();

        protected override DistanceCalculationServiceBase CreateDistanceCalculationServiceCore() => new DistanceCalculationServiceSpy();

        protected override GeocodingServiceBase CreateGeocodingServiceCore() => new GeocodingServiceSpy();

        protected override GeolocationServiceBase CreateGeolocationServiceCore() => new GeolocationServiceSpy();

        protected override PlacePredictionServiceBase CreatePlacePredictionServiceCore() => new PlacePredictionServiceSpy();

        protected override ViewNavigationServiceBase CreateViewNavigationServiceCore(IViewNavigationService navigationService) => new ViewNavigationServiceSpy();

        protected override RideCompareServiceBase CreateRideCompareServiceCore() => new RideCompareServiceSpy();
    }
}
