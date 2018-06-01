using DecathlonApiWrapper.Converters;
using Newtonsoft.Json;

namespace DecathlonApiWrapper.Models.ApiResponce
{
    [JsonConverter(typeof(ApiResponceConverter))]
    internal class ApiResponce
    {
        public string Self { get; set; }
        public string Next { get; set; }
        public int Count { get; set; }
        public FeatureCollection Data { get; set; }
    }
}
