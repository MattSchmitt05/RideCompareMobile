using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    internal abstract class GeocodingServiceBase
    {
        public async Task<IEnumerable<Location>> GetLocationsFromAddressAsync(string address) => await GetLocationsFromAddressAsyncCore(address);
        public async Task<IEnumerable<Placemark>> GetPlacemarksAsync(double lat, double lng) => await GetPlacemarksAsyncCore(lat, lng);

        protected abstract Task<IEnumerable<Location>> GetLocationsFromAddressAsyncCore(string address);
        protected abstract Task<IEnumerable<Placemark>> GetPlacemarksAsyncCore(double lat, double lng);
    }
}
