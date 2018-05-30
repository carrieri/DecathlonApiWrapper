namespace DecathlonApiWrapper.Models
{
    public class GeoLocation : IParameter
    {
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public string AsString => $"{Latitude},{Longitude}";
    }
}
