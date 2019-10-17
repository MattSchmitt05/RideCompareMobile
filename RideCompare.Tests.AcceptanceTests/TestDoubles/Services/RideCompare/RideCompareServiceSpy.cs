using RideCompare.Models;
using RideCompare.Services.RideCompare;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.RideCompare
{
    [ExcludeFromCodeCoverage]
    internal sealed class RideCompareServiceSpy : RideCompareServiceBase
    {
        protected override Task<RideCompareResponse> GetBestRideAsyncCore(ObservableCollection<Pin> locations)
        {
            throw new NotImplementedException();
        }
    }
}
