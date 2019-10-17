using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RideCompare.Services.DistanceCalculation
{
    internal sealed class DistanceCalculationService : DistanceCalculationServiceBase
    {
        protected override double CalculateDistanceApartCore(Location startingLocation, Location selectedPlace, DistanceUnits distanceUnits)
        {
            return Location.CalculateDistance(startingLocation, selectedPlace, distanceUnits);
        }
    }
}
