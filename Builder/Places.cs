using DecathlonApiWrapper.Models;
using DecathlonApiWrapper.Models.ApiResponce;
using Newtonsoft.Json;
using System.Linq;

namespace DecathlonApiWrapper.Builder
{
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
