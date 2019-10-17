using System;
using System.Collections.Generic;
using System.Text;

namespace RideCompare.Services.Deeplinking
{
    internal abstract class DeeplinkingServiceBase
    {
        public void OpenLyft(double startLat, double startLng, double endLat, double endLng) => OpenLyftCore(startLat, startLng, endLat, endLng);
        public void OpenUber(double startLat, double startLng, double endLat, double endLng) => OpenUberCore(startLat, startLng, endLat, endLng);

        protected abstract void OpenLyftCore(double startLat, double startLng, double endLat, double endLng);
        protected abstract void OpenUberCore(double startLat, double startLng, double endLat, double endLng);
    }
}
