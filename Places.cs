using DecathlonApiWrapper.Extensions;
using DecathlonApiWrapper.Models;
using DecathlonApiWrapper.Models.ApiResponce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;

namespace DecathlonApiWrapper
{
    internal enum PlacesParametersType
    {
        origin,
        radius,
        sw,
        ne
    }

    public class PlacesParameters
    {
        private Places Parent;
        public PlacesParameters(Places parent)
        {
            Parent = parent;
        }

        internal Dictionary<PlacesParametersType, string> Parameters { get; } = new Dictionary<PlacesParametersType, string>();

        public PlacesParameters WithOrigin(GeoCoordinate origin, int radius)
        {
            if(radius > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "maximum radius 100");
            }

            Parameters.SetParameter(PlacesParametersType.origin, origin.ToParameter())
                      .SetParameter(PlacesParametersType.radius, radius);

            return this;
        }

        public PlacesParameters WithBoundingBox(GeoCoordinate sw, GeoCoordinate ne)
        {
            var distanceInMeters = sw.GetDistanceTo(ne);
            var hundredKm = 100 * 1000; 
            if (distanceInMeters > hundredKm)
            {
                throw new ArgumentOutOfRangeException($"{nameof(sw)},{nameof(ne)}", distanceInMeters, "maximum bounding box distance 100km");
            }

            Parameters.SetParameter(PlacesParametersType.sw, sw.ToParameter())
                      .SetParameter(PlacesParametersType.ne, ne.ToParameter());

            return this;
        }

        public Places End()
        {
            return Parent;
        }
    }

    public class Places
    {
        private PlacesParameters Parameters;
        public Places()
        {
            Parameters = new PlacesParameters(this);
        }

        private string Url = "https://sportplaces-api.herokuapp.com/api/v1/places";

        public PlacesParameters BuildRequest()
        {
            return Parameters;
        }

        public PagedData<Feature> Fetch()
        {
            var queryParams = string.Join("&", Parameters.Parameters.Select(x => x.Value));
            using (var webClient = new System.Net.WebClient())
            {
                var responce = webClient.DownloadString($"{Url}?{queryParams}");
                var collection = JsonConvert.DeserializeObject<ApiResponce>(responce);
                if (collection?.Data != null)
                {
                    return new PagedData<Feature>
                    {
                        Results = collection.Data.Features,
                        NextPage = collection.Next
                    };
                }
                return null;
            }
        }
    }
}
