using DecathlonApiWrapper.Extensions;
using DecathlonApiWrapper.Models;
using DecathlonApiWrapper.Models.ApiResponce;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DecathlonApiWrapper
{
    internal enum PlacesParametersType
    {
        origin,
        radius
    }

    public class PlacesParameters
    {
        private Places Parent;
        public PlacesParameters(Places parent)
        {
            Parent = parent;
        }

        internal Dictionary<PlacesParametersType, string> Parameters { get; } = new Dictionary<PlacesParametersType, string>();

        public PlacesParameters WithOrigin(GeoLocation origin, int radius)
        {
            Parameters.SetParameter(PlacesParametersType.origin, origin)
                      .SetParameter(PlacesParametersType.radius, radius);
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
