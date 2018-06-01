using DecathlonApiWrapper;
using DecathlonApiWrapper.Builder;
using DecathlonApiWrapper.Models;
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
                _sut.Origin(new GeoCoordinate
                {
                    Latitude = -73.582,
                    Longitude = 45.511
                }, 101);
            });
        }


        [Test]
        public void When_a_raduis_less_than_100_is_suplied_Then_it_works()
        {
            _sut.Origin(new GeoCoordinate
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

            Assert.Throws<ArgumentOutOfRangeException>(() => { _sut.BoundingBox(sw, ne); });
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

            _sut.BoundingBox(sw, ne);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(2));
        }

        [Test]
        public void When_i_specify_a_user_origin_Then_it_should_work()
        {
            var origin = new GeoCoordinate(10, 10);
            _sut.UserOrigin(origin);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_i_specify_sports_ids_Then_it_should_work()
        {
            _sut.Sports(new[] { 1, 2, 3 });

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_i_specify_tags_Then_it_should_work()
        {
            _sut.Tags(new[] { Tags.free, Tags.lessons });

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_I_specify_surface_Then_it_should_work()
        {
            _sut.Surface(new[] { "clay", "concreet" });

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_mindifficulty_Then_it_works()
        {
            _sut.MinDifficulty(Difficulty.Advanced);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_maxdifficulty_Then_it_works()
        {
            _sut.MaxDifficulty(Difficulty.Advanced);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_minduration_Then_it_works()
        {
            _sut.MinDuration(10);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_maxduration_Then_it_works()
        {
            _sut.MaxDuration(10);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_mindistance_Then_it_works()
        {
            _sut.MinDistance(10);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_maxdistance_Then_it_works()
        {
            _sut.MaxDistance(10);

            Assert.That(_sut.Parameters.Count, Is.EqualTo(1));
        }
    }
}
