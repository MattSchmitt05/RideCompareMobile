using RideCompare.Services.DistanceCalculation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.DistanceCalculation
{
    [ExcludeFromCodeCoverage]
    internal sealed class DistanceCalculationServiceSpy : DistanceCalculationServiceBase
    {
        protected override double CalculateDistanceApartCore(Location startingLocation, Location selectedPlace, DistanceUnits distanceUnits)
        {
            throw new NotImplementedException();
        }
    }
}
