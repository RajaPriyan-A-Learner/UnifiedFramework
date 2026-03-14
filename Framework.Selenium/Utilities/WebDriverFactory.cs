using System;
using Framework.Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
// Removed: using OpenQA.Selenium.Remote;

namespace Framework.Selenium.Utilities;

public static class WebDriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browser)
    {
        // We use a switch expression to easily support multiple local browsers
        return browser switch
        {
            BrowserType.Chrome => CreateLocalChromeDriver(),
            BrowserType.Edge=>CreateLocalEdgeDriver(),
            BrowserType.Firefox=>CreateLocalFirefoxDriver(),
            // You can add BrowserType.Firefox => new FirefoxDriver(), etc.
            _ => throw new ArgumentException($"Browser '{browser}' is not supported locally.")
        };
    }

    private static IWebDriver CreateLocalChromeDriver()
    {
        var options = new ChromeOptions();

        // Optional: Add arguments to maximize the window or run headless
        options.AddArgument("--start-maximized");
        // options.AddArgument("--headless"); 

        // This launches the Chrome browser installed on your PC directly
        return new ChromeDriver(options);
    }

    private static IWebDriver CreateLocalEdgeDriver() {
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");
        return new EdgeDriver(options);
    }

    private static IWebDriver CreateLocalFirefoxDriver() {
        // You would need to add the Selenium.WebDriver.GeckoDriver NuGet package for this
        var options = new FirefoxOptions();
        options.AddArgument("--start-maximized");
        return new FirefoxDriver(options);

    }
}