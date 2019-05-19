using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    /// <summary>
    /// Geolocation service that provides geolocation data from
    /// the device's current location.
    /// </summary>
    internal static class GeolocationService
    {
        public static async Task<Location> GetDeviceLocation()
        {
            return await Geolocation.GetLastKnownLocationAsync();
        }
    }
}
