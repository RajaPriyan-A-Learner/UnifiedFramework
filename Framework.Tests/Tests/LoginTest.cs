using NUnit.Framework;

namespace Framework.Tests
{
    [TestFixture]
    public class LoginAppTest : MobileBaseTest
    {
        [Test]
        public void NativeAppLogin_ShouldSucceed()
        {
            // We use Accessibility IDs which work natively on both iOS and Android!
            App.Type("accessibilityid=username_input", "testuser");
            App.Type("accessibilityid=password_input", "password123");
            App.Tap("accessibilityid=login_button");

            string welcomeMessage = App.GetText("accessibilityid=welcome_text");
            Assert.That(welcomeMessage, Is.EqualTo("Welcome, testuser!"));
        }
    }
}