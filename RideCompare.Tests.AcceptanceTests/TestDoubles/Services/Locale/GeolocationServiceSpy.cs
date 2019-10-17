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
    internal sealed class GeolocationServiceSpy : GeolocationServiceBase
    {
        protected override Task<Location> GetDeviceLocationAsyncCore()
        {
            throw new NotImplementedException();
        }
    }
}
