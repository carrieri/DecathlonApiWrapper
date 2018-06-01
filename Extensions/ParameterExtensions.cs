using DecathlonApiWrapper.Builder;
using DecathlonApiWrapper.Models;
using System.Collections.Generic;
using System.Linq;

namespace DecathlonApiWrapper.Extensions
{
    internal static class ParameterExtensions
    {
        private static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            string value)
        {
            var str = $"{type.ToString()}={value}";
            if (parameters.ContainsKey(type))
            {
                parameters[type] = str;
            }
            else
            {
                parameters.Add(type, str);
            }
            return parameters;
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            IParameter value)
        {
            return SetParameter(parameters, type, value.AsString);
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            int value)
        {
            return SetParameter(parameters, type, value.ToString());
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            IEnumerable<int> ints)
        {
            return SetParameter(parameters, type, string.Join(",", ints));
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            IEnumerable<Tags> tags)
        {
            var strTargs = tags.Select(x => x.ToString());
            return SetParameter(parameters, type, string.Join(",", strTargs));
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(
            this Dictionary<PlacesParametersType, string> parameters,
            PlacesParametersType type,
            IEnumerable<string> strings)
        {
            return SetParameter(parameters, type, string.Join(",", strings));
        }
    }
}
