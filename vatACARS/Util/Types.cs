using System;

namespace vatACARS.Util
{
    public class APIResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class LatLon
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class LoginResponse : APIResponse
    {
        public StationInformation ATSU { get; set; }
    }

    public class Sector
    {
        public string Callsign { get; set; }
        public string Frequency { get; set; }
        public string Name { get; set; }
    }

    public class StationInformation
    {
        public string ApproxLoc { get; set; }
        public string Cid { get; set; }
        public string Id { get; set; }
        public DateTime Opened { get; set; }
        public string Sectors { get; set; }
        public string Station_Code { get; set; }
    }

    public enum MessageState
    {
        Downlink = 0,
        DownlinkResponseNotRequired = 1,
        ADSC = 2,
        StbyDefer = 3,
        Uplink = 4,
        Finished = 5
    }
}