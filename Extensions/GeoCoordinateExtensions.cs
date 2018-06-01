using DecathlonApiWrapper.Models;
using System;
using System.Device.Location;

namespace DecathlonApiWrapper.Extensions
{
    internal class Parameter<T> : IParameter
    {
        private T _instace;
        private Func<T, string> _stringnify { get; set; }

        public Parameter(T instance, Func<T, string> resolver)
        {
            _instace = instance;
            _stringnify = resolver;
        }
        
        public string AsString => _stringnify(_instace);
    }

    public static class GeoCoordinateExtensions
    {
        internal static IParameter ToParameter(this GeoCoordinate coords)
        {
            var parameter = new Parameter<GeoCoordinate>(coords, (x) => $"{ x.Longitude },{ x.Latitude}");
            return parameter;
        }
    }
}
