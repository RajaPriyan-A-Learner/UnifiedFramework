using Framework.Core.Enums;
using Framework.Tests.BaseTests;
using NUnit.Framework;

namespace Framework.Tests.Tests
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Edge)]
    public class SearchTest(BrowserType browserType) : UIBaseTest(browserType)
    {
        [Test]
        public void PerformSearch_ShouldWork()
        {
            // Arrange
            UI.NavigateTo("https://www.wikipedia.org/");

            // Act: We pass plain strings just like our interface requires!
            UI.Type("id=searchInput", "SOLID Object-Oriented Design");
            UI.Click("css=button[type='submit']");

            // Assert
            string titleText = UI.GetText("id=firstHeading");
            Assert.That(titleText, Does.Contain("SOLID"));
        }
    }
}