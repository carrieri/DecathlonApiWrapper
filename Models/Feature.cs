using DecathlonApiWrapper.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DecathlonApiWrapper.Models
{
    [JsonConverter(typeof(FeatureConverter))]
    public class Feature
    {
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string GooglePlaceId { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public AddressComponent Address { get; set; }
        public List<Activity> Activities { get; set; }
        public GeoLocation GeoLocation { get; set; }
        public User User { get; set; }
        public Partner Partner { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
