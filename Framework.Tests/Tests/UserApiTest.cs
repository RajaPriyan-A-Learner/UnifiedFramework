using NUnit.Framework;
using System.Threading.Tasks;

namespace Framework.Tests
{
    [TestFixture]
    [Category("API")] // Categorizing for Jenkins/GitHub Actions filtering
    public class UserApiTests : ApiBaseTest
    {
        [Test]
        public async Task GetSingleUser_ValidateEmail()
        {
            // Act
            var response = await Api.GetAsync<UserResponse>("/api/users/2");

            // Assert
            Assert.That(response.Data.Email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(response.Data.FirstName, Is.EqualTo("Janet"));
        }
    }
}