using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    /// <summary>
    /// Geocoding service that provides geolocation data from an
    /// entered address.
    /// </summary>
    internal sealed class GeocodingService : GeocodingServiceBase
    {
        protected override async Task<IEnumerable<Location>> GetLocationsFromAddressAsyncCore(string address)
        {
            return await Geocoding.GetLocationsAsync(address);
        }

        protected override async Task<IEnumerable<Placemark>> GetPlacemarksAsyncCore(double lat, double lng)
        {
            return await Geocoding.GetPlacemarksAsync(lat, lng);
        }
    }
}
