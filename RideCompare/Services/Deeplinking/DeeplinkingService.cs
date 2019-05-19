using System;
using Xamarin.Forms;

namespace RideCompare.Services.Deeplinking
{
    internal sealed class DeeplinkingService
    {
        private readonly double _startLat;
        private readonly double _startLng;
        private readonly double _endLat;
        private readonly double _endLng;

        public DeeplinkingService(double startLat, double startLng, double endLat, double endLng)
        {
            _startLat = startLat;
            _startLng = startLng;
            _endLat = endLat;
            _endLng = endLng;
        }

        public void OpenLyft()
        {
            var uri = new Uri($"https://lyft.com/ride?id=lyft&pickup[latitude]={_startLat}&pickup[longitude]={_startLng}&destination[latitude]={_endLat}&destination[longitude]={_endLng}");
            Device.OpenUri(uri);
        }

        public void OpenUber()
        {
            var uri = new Uri($"https://m.uber.com/ul/?action=setPickup&pickup[latitude]={_startLat}&pickup[longitude]={_startLng}&dropoff[latitude]={_endLat}&dropoff[longitude]={_endLng}");
            Device.OpenUri(uri);
        }
    }
}
