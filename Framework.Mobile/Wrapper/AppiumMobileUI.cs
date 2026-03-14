using System;
using Framework.Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Framework.Mobile
{
    public class AppiumMobileUI : IMobileUI
    {
        private readonly AppiumDriver _driver;

        public AppiumMobileUI(AppiumDriver driver)
        {
            _driver = driver;
        }

        private By GetBy(string locator)
        {
            var parts = locator.Split(new[] { '=' }, 2);
            if (parts.Length != 2) throw new ArgumentException($"Locator '{locator}' must be 'type=value'");

            string type = parts[0].ToLower();
            string value = parts[1];

            return type switch
            {
                "id" => By.Id(value),
                "xpath" => By.XPath(value),
                "accessibilityid" => MobileBy.AccessibilityId(value), // Appium specific!
                _ => throw new ArgumentException($"Locator type '{type}' is not supported.")
            };
        }

        public void Tap(string locator) => _driver.FindElement(GetBy(locator)).Click();

        public void Type(string locator, string text)
        {
            var element = _driver.FindElement(GetBy(locator));
            element.Clear();
            element.SendKeys(text);
        }

        public string GetText(string locator) => _driver.FindElement(GetBy(locator)).Text;

        public void Quit() => _driver.Quit();
    }
}