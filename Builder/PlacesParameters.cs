using DecathlonApiWrapper.Extensions;
using DecathlonApiWrapper.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;

namespace DecathlonApiWrapper.Builder
{
    public class PlacesParameters
    {
        private Places Parent;
        public PlacesParameters(Places parent)
        {
            Parent = parent;
        }

        internal Dictionary<PlacesParametersType, string> Parameters { get; } = new Dictionary<PlacesParametersType, string>();

        public PlacesParameters Origin(GeoCoordinate origin, int radius)
        {
            if (radius > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "maximum radius 100");
            }

            Parameters.SetParameter(PlacesParametersType.origin, origin.ToParameter())
                      .SetParameter(PlacesParametersType.radius, radius);

            return this;
        }

        public PlacesParameters BoundingBox(GeoCoordinate sw, GeoCoordinate ne)
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

        public PlacesParameters UserOrigin(GeoCoordinate userOrigin)
        {
            Parameters.SetParameter(PlacesParametersType.user_origin, userOrigin.ToParameter());

            return this;
        }

        public PlacesParameters Sports(IEnumerable<int> sports)
        {
            Parameters.SetParameter(PlacesParametersType.sports, sports);

            return this;
        }

        public PlacesParameters Tags(IEnumerable<Tags> tags)
        {
            Parameters.SetParameter(PlacesParametersType.tags, tags);

            return this;
        }

        public PlacesParameters Surface(string[] surfaces)
        {
            Parameters.SetParameter(PlacesParametersType.surface, surfaces);

            return this;
        }

        public PlacesParameters MaxDifficulty(Difficulty difficulty)
        {
            Parameters.SetParameter(PlacesParametersType.max_difficulty, (int)difficulty);

            return this;
        }

        public PlacesParameters MinDifficulty(Difficulty difficulty)
        {
            Parameters.SetParameter(PlacesParametersType.min_difficulty, (int)difficulty);

            return this;
        }

        public PlacesParameters MinDuration(int duration)
        {
            Parameters.SetParameter(PlacesParametersType.min_duration, duration);

            return this;
        }

        public PlacesParameters MaxDuration(int duration)
        {
            Parameters.SetParameter(PlacesParametersType.max_duration, duration);

            return this;
        }

        public PlacesParameters MinDistance(int distance)
        {
            Parameters.SetParameter(PlacesParametersType.min_distance, distance);

            return this;
        }

        public PlacesParameters MaxDistance(int distance)
        {
            Parameters.SetParameter(PlacesParametersType.max_distance, distance);

            return this;
        }
    }
}
