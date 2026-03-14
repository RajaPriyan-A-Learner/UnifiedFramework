using Framework.Core.Interfaces;
using NUnit.Framework;
using Framework.API.Wrapper;

namespace Framework.Tests.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private IApiClient _api;

        [SetUp]
        public void SetUp()
        {
            // Composition Root: We wire up the interface to RestSharp here
            // using the base URL of our target environment
            _api = new RestSharpClient("https://reqres.in");
        }

        [Test]
        public async Task GetUser_ShouldReturnCorrectData()
        {
            // Act: We call the API and auto-deserialize it into our C# Model
            var response = await _api.GetAsync<UserResponse>("/api/users/2");

            // Assert: Standard NUnit assertions
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Data!.Id, Is.EqualTo(2));
            Assert.That(response.Data.Email, Is.EqualTo("janet.weaver@reqres.in"));
        }
    }
}