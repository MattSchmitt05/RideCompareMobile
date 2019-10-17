using RideCompare.Services.Locale;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Locale
{
    [ExcludeFromCodeCoverage]
    internal sealed class GeocodingServiceSpy : GeocodingServiceBase
    {
        protected override Task<IEnumerable<Location>> GetLocationsFromAddressAsyncCore(string address)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Placemark>> GetPlacemarksAsyncCore(double lat, double lng)
        {
            throw new NotImplementedException();
        }
    }
}
