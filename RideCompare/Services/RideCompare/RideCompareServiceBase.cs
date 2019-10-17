using RideCompare.Models;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace RideCompare.Services.RideCompare
{
    internal abstract class RideCompareServiceBase
    {
        public async Task<RideCompareResponse> GetBestRideAsync(ObservableCollection<Pin> locations) => await GetBestRideAsyncCore(locations);

        protected abstract Task<RideCompareResponse> GetBestRideAsyncCore(ObservableCollection<Pin> locations);
    }
}
