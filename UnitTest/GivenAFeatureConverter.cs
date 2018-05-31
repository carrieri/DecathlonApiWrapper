using DecathlonApiWrapper.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    [Category("Small")]
    public class GivenAFeatureConverter
    {
        [Test]
        public void When_I_convert_a_feature_Then_it_should_work()
        {
            var json = "{    \"type\": \"Feature\",    \"properties\": {   \"partner\":{\"name\":\"SportWhere\",\"slug\":\"sportwhere\",\"website\":\"https://www.sportwhere.com/\",\"logo_url\":\"https://www.sportwhere.com/wp-content/uploads/2015/11/SportWhere_Logo_site.png\"},      \"uuid\": \"8b1e3027-e438-42c2-92ab-5ebd23f68d54\",        \"name\": \"McConnell Arena\",    \"user\":{\"id\":0,\"first_name\":\"Decathlon\",\"last_name\":\"IT\",\"staff\":true},        \"google_place_id\": \"ChIJ5XD-5zAayUwRIK7t7t89ZJ0\",        \"contact_details\": {            \"email\": \"some@email.com\",            \"phone\": \"+1 514-398-7017\",            \"website\": \"testvalue\",            \"booking_url\": \"testvalue\",            \"facebook_username\": \"testvalue\"        },        \"address_components\": {            \"address\": \"3883 Rue University\",            \"city\": \"Montréal\",            \"province\": \"Québec\",            \"country\": \"CA\"        },        \"activities\": [          {    \"photo_reference\": \"CmRaAAAANDOXnKTz_P4N82REKOF--yf81qx6b_JPeSR5Qv7G-JOTwhmrOaWzrwlyEZy6FHhuxVxBrQ8N1UbMfTmGxszv_6Jz5Ex5mqiz4HACg2dDAULcHzU-r3INyTD4BAYFzi4aEhBVXQLTQFGzuDW2vFem5qx-GhRdExX9jSv_tPSBTehxORaRowhwXQ\",        \"sport_id\": 160,            \"tags\": [\"str1\", \"str2\"],     \"user\":{\"id\":0,\"first_name\":\"Decathlon\",\"last_name\":\"IT\",\"staff\":true},        \"difficulty\": 2,            \"distance\": 10          }        ]    },    \"geometry\": {        \"type\": \"Point\",        \"coordinates\": [            -73.5826985,            45.5119864        ]    }}";

            var obj = JsonConvert.DeserializeObject<Feature>(json);

            Assert.That(obj.Uuid, Is.EqualTo("8b1e3027-e438-42c2-92ab-5ebd23f68d54"));
            Assert.That(obj.Name, Is.EqualTo("McConnell Arena"));
            Assert.That(obj.GooglePlaceId, Is.EqualTo("ChIJ5XD-5zAayUwRIK7t7t89ZJ0"));

            Assert.That(obj.ContactDetails, Is.Not.Null);
            Assert.That(obj.ContactDetails.Email, Is.EqualTo("some@email.com"));
            Assert.That(obj.ContactDetails.Phone, Is.EqualTo("+1 514-398-7017"));
            Assert.That(obj.ContactDetails.BookingUrl, Is.EqualTo("testvalue"));
            Assert.That(obj.ContactDetails.Website, Is.EqualTo("testvalue"));
            Assert.That(obj.ContactDetails.FacebookUsername, Is.EqualTo("testvalue"));

            Assert.That(obj.Address, Is.Not.Null);
            Assert.That(obj.Address.Address, Is.EqualTo("3883 Rue University"));
            Assert.That(obj.Address.City, Is.EqualTo("Montréal"));
            Assert.That(obj.Address.Province, Is.EqualTo("Québec"));
            Assert.That(obj.Address.Country, Is.EqualTo("CA"));

            Assert.That(obj.Activities, Is.Not.Null);
            Assert.That(obj.Activities.Count, Is.EqualTo(1));
            var act = obj.Activities.First();
            Assert.That(act.Distance, Is.EqualTo(10));
            Assert.That(act.SportId, Is.EqualTo(160));
            Assert.That(act.Tags.Count, Is.EqualTo(2));
            Assert.That(act.Difficulty, Is.EqualTo(Difficulty.Advanced));
            Assert.That(act.PhotoReference, Is.EqualTo("CmRaAAAANDOXnKTz_P4N82REKOF--yf81qx6b_JPeSR5Qv7G-JOTwhmrOaWzrwlyEZy6FHhuxVxBrQ8N1UbMfTmGxszv_6Jz5Ex5mqiz4HACg2dDAULcHzU-r3INyTD4BAYFzi4aEhBVXQLTQFGzuDW2vFem5qx-GhRdExX9jSv_tPSBTehxORaRowhwXQ"));

            Assert.That(act.User, Is.Not.Null);
            Assert.That(act.User.Id, Is.EqualTo(0));
            Assert.That(act.User.FirstName, Is.EqualTo("Decathlon"));
            Assert.That(act.User.LastName, Is.EqualTo("IT"));
            Assert.That(act.User.Staff, Is.True);

            Assert.That(obj.GeoLocation, Is.Not.Null);
            Assert.That(obj.GeoLocation.Longitude, Is.EqualTo(45.5119864m));
            Assert.That(obj.GeoLocation.Latitude, Is.EqualTo(-73.5826985m));

            Assert.That(obj.User, Is.Not.Null);
            Assert.That(obj.User.Id, Is.EqualTo(0));
            Assert.That(obj.User.FirstName, Is.EqualTo("Decathlon"));
            Assert.That(obj.User.LastName, Is.EqualTo("IT"));
            Assert.That(obj.User.Staff, Is.True);

            Assert.That(obj.Partner, Is.Not.Null);
            Assert.That(obj.Partner.Name, Is.EqualTo("SportWhere"));
            Assert.That(obj.Partner.Slug, Is.EqualTo("sportwhere"));
            Assert.That(obj.Partner.WebSite, Is.EqualTo("https://www.sportwhere.com/"));
            Assert.That(obj.Partner.LogoUrl, Is.EqualTo("https://www.sportwhere.com/wp-content/uploads/2015/11/SportWhere_Logo_site.png"));

        }
    }
}
