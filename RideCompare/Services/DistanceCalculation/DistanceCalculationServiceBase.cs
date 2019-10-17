using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RideCompare.Services.DistanceCalculation
{
    internal abstract class DistanceCalculationServiceBase
    {
        public double CalculateDistanceApart(Location startingLocation, Location selectedPlace, DistanceUnits distanceUnits) => CalculateDistanceApartCore(startingLocation, selectedPlace, distanceUnits);

        protected abstract double CalculateDistanceApartCore(Location startingLocation, Location selectedPlace, DistanceUnits distanceUnits);
    }
}
