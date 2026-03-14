using Allure.NUnit;
using Framework.Core.Interfaces;
using Framework.Mobile;
using NUnit.Framework;
using System;

namespace Framework.Tests
{
    [AllureNUnit]
    public class MobileBaseTest
    {
        protected IMobileUI App { get; private set; }

        [SetUp]
        public void SetUp()
        {
            // Pipeline variables for OS and the BrowserStack App ID
            string platform = TestContext.Parameters["Platform"] ?? "Android";
            string appUrl = TestContext.Parameters["AppUrl"] ?? "bs://your-app-id-here";

            var driver = MobileDriverFactory.CreateDriver(platform, appUrl);
            App = new AppiumMobileUI(driver);
        }

        [TearDown]
        public void TearDown()
        {
            App?.Quit();
        }
    }
}