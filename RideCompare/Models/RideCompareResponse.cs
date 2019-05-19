namespace RideCompare.Models
{
    internal sealed class RideCompareResponse
    {
        public string Timestamp { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public BestRideResult BestRide { get; set; }

        internal sealed class BestRideResult
        {
            public string RideShareProvider { get; set; }
            public string RideCost { get; set; }
            public string RideEta { get; set; }
            public string LowestRideCostProvider { get; set; }
            public string ShortestRideEtaProvider { get; set; }
        }
    }
}
