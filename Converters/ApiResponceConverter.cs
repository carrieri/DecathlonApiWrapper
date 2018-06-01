using DecathlonApiWrapper.Models;
using DecathlonApiWrapper.Models.ApiResponce;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace DecathlonApiWrapper.Converters
{
    internal class ApiResponceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            dynamic obj = JObject.Load(reader);

            var responce = new ApiResponce
            {
                Count = obj.count,
                Self = obj.links.self,
                Next = obj.links.next,
                Data = obj.data.ToObject<FeatureCollection>()
            };

            return responce;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
