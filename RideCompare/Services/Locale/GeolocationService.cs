using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    /// <summary>
    /// Geolocation service that provides geolocation data from
    /// the device's current location.
    /// </summary>
    internal sealed class GeolocationService : GeolocationServiceBase
    {
        protected override async Task<Location> GetDeviceLocationAsyncCore()
        {
            return await Geolocation.GetLastKnownLocationAsync();
        }
    }
}
