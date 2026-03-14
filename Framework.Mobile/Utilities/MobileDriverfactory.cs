using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;

namespace Framework.Mobile
{
    public static class MobileDriverFactory
    {
        public static AppiumDriver CreateDriver(string platform, string appUrl)
        {
            var options = new AppiumOptions();

            // BrowserStack Cloud Authentication & Config
            var bstackOptions = new Dictionary<string, object>
            {
                { "userName", Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME") ?? "YOUR_USERNAME" },
                { "accessKey", Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY") ?? "YOUR_ACCESS_KEY" },
                { "projectName", "Unified Framework" },
                { "buildName", "Mobile Appium Build" },
                { "sessionName", "Cross-Platform Mobile Test" }
            };

            options.AddAdditionalAppiumOption("bstack:options", bstackOptions);

            // The uploaded app URL on BrowserStack (e.g., bs://<hashed-id>)
            options.AddAdditionalAppiumOption("appium:app", appUrl);

            // The BrowserStack Hub
            Uri cloudHub = new Uri("https://hub-cloud.browserstack.com/wd/hub");

            if (platform.Equals("Android", StringComparison.OrdinalIgnoreCase))
            {
                options.PlatformName = "Android";
                options.AutomationName = "UiAutomator2";
                options.AddAdditionalAppiumOption("appium:deviceName", "Google Pixel 7");
                return new AndroidDriver(cloudHub, options);
            }
            else
            {
                options.PlatformName = "iOS";
                options.AutomationName = "XCUITest";
                options.AddAdditionalAppiumOption("appium:deviceName", "iPhone 14");
                return new IOSDriver(cloudHub, options);
            }
        }
    }
}