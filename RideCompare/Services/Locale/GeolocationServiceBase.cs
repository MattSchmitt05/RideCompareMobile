using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RideCompare.Services.Locale
{
    internal abstract class GeolocationServiceBase
    {
        public async Task<Location> GetDeviceLocationAsync() => await GetDeviceLocationAsyncCore();

        protected abstract Task<Location> GetDeviceLocationAsyncCore();
    }
}
