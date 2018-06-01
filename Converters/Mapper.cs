﻿using DecathlonApiWrapper.Models;
using System.Collections.Generic;

namespace DecathlonApiWrapper.Converters
{
    internal class Point
    {
        public decimal[] coordinates { get; set; }
    }

    internal class Mapper
    {
        public static Partner MapPartner(dynamic partner)
        {
            if (partner == null)
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

        public static User MapUser(dynamic user)
        {
            if (user == null)
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

        public static GeoLocation MapGeoLocation(dynamic location)
        {
            var point = location.ToObject<Point>();
            var geoLocation = new GeoLocation
            {
                Longitude = point.coordinates[1],
                Latitude = point.coordinates[0]
            };

            return geoLocation;
        }

        public static AddressComponent MapAddress(dynamic address)
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

        public static List<Activity> MapActivities(dynamic activities)
        {
            var list = new List<Activity>();

            foreach (var act in activities)
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

        public static ContactDetails MapContractDetails(dynamic contactObj)
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
    }
}