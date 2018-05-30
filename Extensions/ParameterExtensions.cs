using System.Collections.Generic;

namespace DecathlonApiWrapper.Extensions
{
    internal static class ParameterExtensions
    {
        private static Dictionary<PlacesParametersType, string> SetParameter(this Dictionary<PlacesParametersType, string> parameters, PlacesParametersType type, string value)
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

        public static Dictionary<PlacesParametersType, string> SetParameter(this Dictionary<PlacesParametersType, string> parameters, PlacesParametersType type, IParameter value)
        {
            return SetParameter(parameters, type, value.AsString);
        }

        public static Dictionary<PlacesParametersType, string> SetParameter(this Dictionary<PlacesParametersType, string> parameters, PlacesParametersType type, int value)
        {
            return SetParameter(parameters, type, value.ToString());
        }
    }
}
