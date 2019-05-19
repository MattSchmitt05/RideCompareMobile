using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    /// <summary>
    /// Geocoding service that provides geolocation data from an
    /// entered address.
    /// </summary>
    internal static class GeocodingService
    {
        public static async Task<IEnumerable<Location>> GetLocationsFromAddress(string address)
        {
            return await Geocoding.GetLocationsAsync(address);
        }

        public static async Task<IEnumerable<Placemark>> GetPlacemarks(double lat, double lng)
        {
            return await Geocoding.GetPlacemarksAsync(lat, lng);
        }
    }
}
