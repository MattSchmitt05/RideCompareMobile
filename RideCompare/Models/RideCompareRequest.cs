namespace RideCompare.Models
{
    internal sealed class RideCompareRequest
    {
        public RideCompareLocation StartingLocation { get; set; }
        public RideCompareLocation DestinationLocation { get; set; }

        internal sealed class RideCompareLocation
        {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
    }
}
