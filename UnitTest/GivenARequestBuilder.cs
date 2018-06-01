using DecathlonApiWrapper;
using NUnit.Framework;
using System;
using System.Device.Location;

namespace UnitTest
{
    [TestFixture]
    [Category("Small")]
    [Category("Builder")]
    [Category("Palces")]
    class GivenARequestBuilder
    {
        private PlacesParameters _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PlacesParameters(new Places());
        }

        [Test]
        public void When_a_raduis_greater_than_100_is_suplied_Then_it_will_throw_an_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _sut.WithOrigin(new GeoCoordinate
                {
                    Latitude = -73.582,
                    Longitude = 45.511
                }, 101);
            });
        }


        [Test]
        public void When_a_raduis_less_than_100_is_suplied_Then_it_works()
        {
            _sut.WithOrigin(new GeoCoordinate
            {
                Latitude = -73.582,
                Longitude = 45.511
            }, 100);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_I_check_a_bounding_box_greater_than_100Km_Then_it_should_throw_an_exception()
        {
            var sw = new GeoCoordinate
            {
                Latitude = -73.582,
                Longitude = 45.511
            };

            var ne = new GeoCoordinate
            {
                Latitude = -43.582,
                Longitude = 35.511
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => { _sut.WithBoundingBox(sw, ne); });
        }

        [Test]
        public void When_I_check_a_bounding_box_less_than_100Km_Then_it_should_work()
        {
            var sw = new GeoCoordinate
            {
                Latitude = -73.582,
                Longitude = 45.511
            };

            var ne = new GeoCoordinate
            {
                Latitude = -73.582,
                Longitude = 44.511
            };

            _sut.WithBoundingBox(sw, ne);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(2));
        }
    }
}
