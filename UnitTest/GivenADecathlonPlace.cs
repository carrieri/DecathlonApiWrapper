using DecathlonApiWrapper;
using NUnit.Framework;
using DecathlonApiWrapper.Models;
using System.Device.Location;

namespace UnitTest
{
    
    [TestFixture]
    [Category("Integration")]
    public class GivenADecathlonPlace
    {
        [Test]
        public void When_I_fetch_a_place_by_origin_Then_I_should_get_locations()
        {
            var decathlon = new Decathlon();
            var data = decathlon.SearchForPlaces()
                .BuildRequest()
                    .Origin(new GeoCoordinate
                    {
                        Longitude = -73.582,
                        Latitude = 45.511
                    }, 10)
                    .End()
                .Fetch();

            Assert.That(data, Is.Not.Null);
            Assert.That(data.Results.Count, Is.GreaterThan(0));
        }
    }
}