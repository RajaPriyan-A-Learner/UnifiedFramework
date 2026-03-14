using Framework.Core.Enums;
using Framework.Core.Interfaces;
using Framework.Selenium;
using Framework.Selenium.Utilities;
using Framework.Selenium.Wrapper;
using NUnit.Framework;

namespace Framework.Tests.BaseTests
{
    public class UIBaseTest
    {
        protected IWebUI UI { get; private set; }
        private readonly BrowserType _browserType;

        // Constructor receives the browser type from the TestFixture
        public UIBaseTest(BrowserType browserType)
        {
            _browserType = browserType;
        }

        [SetUp]
        public void SetUp()
        {
            // Use the injected browser type instead of hardcoding Chrome
            var driver = WebDriverFactory.CreateDriver(_browserType);
            UI = new SeleniumWebUI(driver);
        }

        [TearDown]
        public void TearDown()
        {
            UI?.Quit();
        }
    }
}