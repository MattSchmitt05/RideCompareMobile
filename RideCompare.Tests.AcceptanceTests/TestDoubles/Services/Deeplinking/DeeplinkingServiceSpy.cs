using RideCompare.Services.Deeplinking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Deeplinking
{
    [ExcludeFromCodeCoverage]
    internal sealed class DeeplinkingServiceSpy : DeeplinkingServiceBase
    {
        protected override void OpenLyftCore(double startLat, double startLng, double endLat, double endLng)
        {
            throw new NotImplementedException();
        }

        protected override void OpenUberCore(double startLat, double startLng, double endLat, double endLng)
        {
            throw new NotImplementedException();
        }
    }
}
