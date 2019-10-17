using System;
using Xamarin.Forms;

namespace RideCompare.Services.Deeplinking
{
    internal sealed class DeeplinkingService : DeeplinkingServiceBase
    {
        protected override void OpenLyftCore(double startLat, double startLng, double endLat, double endLng)
        {
            var uri = new Uri($"https://lyft.com/ride?id=lyft&pickup[latitude]={startLat}&pickup[longitude]={startLng}&destination[latitude]={endLat}&destination[longitude]={endLng}");
            Device.OpenUri(uri);
        }

        protected override void OpenUberCore(double startLat, double startLng, double endLat, double endLng)
        {
            var uri = new Uri($"https://m.uber.com/ul/?action=setPickup&pickup[latitude]={startLat}&pickup[longitude]={startLng}&dropoff[latitude]={endLat}&dropoff[longitude]={endLng}");
            Device.OpenUri(uri);
        }
    }
}
