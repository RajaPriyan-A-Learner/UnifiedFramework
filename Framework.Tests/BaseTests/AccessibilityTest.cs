using Allure.NUnit;
using Framework.Accessibility;
using Framework.Core.Enums;
using Framework.Core.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Tests.BaseTests
{
    [AllureNUnit]
    // Use the primary constructor to pass the browserType directly to the base class
    public class AccessibilityBaseTest(BrowserType browserType) : UIBaseTest(browserType)
    {
        protected IAccessibilityScanner Scanner { get; private set; }

        [SetUp]
        public void AccessibilitySetUp()
        {
            // 1. UIBaseTest.SetUp() (via BaseTest) runs first, initializing the 'UI' object
            // 2. Extract the driver from the abstraction
            var driver = (IWebDriver)UI.GetDriver();

            // 3. Initialize the scanner implementation
            Scanner = new AxeScanner(driver);
        }

        [TearDown]
        public void AccessibilityTearDown()
        {
            Scanner = null;
        }
    }
}