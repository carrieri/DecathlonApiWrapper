using Newtonsoft.Json;
using NUnit.Framework;
using DecathlonApiWrapper.Models.ApiResponce;

namespace UnitTest
{
    [TestFixture]
    [Category("Small")]
    class GivenAPagedConverter
    {
        [Test]
        public void When_I_convert_a_paged_responce_Then_it_should_work()
        {
            var json = "{\"links\":{\"self\":\"https://sportplaces-api.herokuapp.com/api/v1/places?origin=-73.582%2C45.511&page=1&radius=10\",\"next\":\"https://sportplaces-api.herokuapp.com/api/v1/places?origin=-73.582%2C45.511&page=2&radius=10\"},\"count\":100,\"data\":{\"type\":\"FeatureCollection\",\"features\":[]}}";

            var responce = JsonConvert.DeserializeObject<ApiResponce>(json);


            Assert.That(responce.Count, Is.EqualTo(100));
            Assert.That(responce.Next.Contains("page=2"), Is.True);
            Assert.That(responce.Self.Contains("page=1"), Is.True);
            Assert.That(responce.Data, Is.Not.Null);
            Assert.That(responce.Data.Features, Is.Empty);
        }
    }
}
