using DecathlonApiWrapper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DecathlonApiWrapper.Converters
{
    internal class FeatureConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            dynamic obj = JObject.Load(reader);

            var props = obj.properties;

            var feature = new Feature()
            {
                Uuid = obj.properties.uuid,
                Name = obj.properties.name,
                GooglePlaceId = obj.properties.google_place_id,
                User = Mapper.MapUser(obj.properties?.user),
                ContactDetails = Mapper.MapContractDetails(obj.properties?.contact_details),
                Activities = Mapper.MapActivities(obj.properties?.activities),
                Address = Mapper.MapAddress(obj.properties?.address_components),
                Partner = Mapper.MapPartner(obj.properties?.partner),
                GeoLocation = Mapper.MapGeoLocation(obj.geometry)
            };

            return feature;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
