using Allure.Net.Commons;
using Allure.NUnit;
using Framework.Core.Enums;
using Framework.Core.Interfaces;
using Framework.Selenium;
using Framework.Selenium.Utilities;
using Framework.Selenium.Wrapper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Tests.BaseTests
{
    [AllureNUnit]
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
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                AddScreenshotToAllure();
            }
            UI?.Quit();
        }

        private void AddScreenshotToAllure()
        {
            var driver = (ITakesScreenshot)UI.GetDriver();
            byte[] screenshot = driver.GetScreenshot().AsByteArray;
            AllureApi.AddAttachment("Screenshot", "image/png", screenshot);
        }
    }
}