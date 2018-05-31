using DecathlonApiWrapper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

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
                User = MapUser(obj.properties?.user),
                ContactDetails = MapContractDetails(obj.properties?.contact_details),
                Activities = MapActivities(obj.properties?.activities),
                Address = MapAddress(obj.properties?.address_components),
                Partner = MapPartner(obj.properties?.partner),
                GeoLocation = MapGeoLocation(obj.geometry)
            };

            return feature;
        }

        internal class Point
        {
            public decimal[] coordinates { get; set; }
        }

        private Partner MapPartner(dynamic partner)
        {
            if(partner == null)
            {
                return null;
            }
            var partnerInst = new Partner
            {
                Name = partner.name,
                Slug = partner.slug,
                WebSite = partner.website,
                LogoUrl = partner.logo_url
            };

            return partnerInst;
        }

        private User MapUser(dynamic user)
        {
            if(user == null)
            {
                return null;
            }
            var userInst = new User
            {
                Id = user.id,
                FirstName = user.first_name,
                LastName = user.last_name,
                Staff = user.staff
            };
            return userInst;
        }

        private GeoLocation MapGeoLocation(dynamic location)
        {
            var point = location.ToObject<Point>();
            var geoLocation = new GeoLocation
            {
                Longitude = point.coordinates[1],
                Latitude = point.coordinates[0]
            };

            return geoLocation;
        }

        private AddressComponent MapAddress(dynamic address)
        {
            var addressComponent = new AddressComponent
            {
                Address = address?.address,
                City = address?.city,
                Country = address?.country,
                Province = address?.province
            };

            return addressComponent;
        }

        private List<Activity> MapActivities(dynamic activities)
        {
            var list = new List<Activity>();

            foreach(var act in activities)
            {
                var activity = new Activity
                {
                    SportId = act.sport_id,
                    Tags = act.tags.ToObject<List<string>>(),
                    Distance = act.distance,
                    Difficulty = act.difficulty,
                    User = MapUser(act?.user),
                    PhotoReference = act.photo_reference
                };

                list.Add(activity);
            }

            return list;
        }

        private ContactDetails MapContractDetails(dynamic contactObj)
        {
            var contactDetails = new ContactDetails()
            {
                BookingUrl = contactObj?.booking_url,
                Email = contactObj?.email,
                FacebookUsername = contactObj?.facebook_username,
                Phone = contactObj?.phone,
                Website = contactObj?.website
            };
            return contactDetails;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
