using Framework.Core.Interfaces;
using OpenQA.Selenium;

namespace Framework.Selenium.Wrapper;

public class SeleniumWebUI : IWebUI
{
    private readonly IWebDriver _driver;

    public SeleniumWebUI(IWebDriver driver)
    {
        _driver = driver;
    }

    // Helper method to parse strings like "id=loginBtn" or "xpath=//button"
    private By GetBy(string locator)
    {
        // Split the string at the first '=' sign
        var parts = locator.Split(new[] { '=' }, 2);

        if (parts.Length != 2)
        {
            throw new ArgumentException($"Locator '{locator}' must be in the format 'type=value'");
        }

        string type = parts[0].ToLower();
        string value = parts[1];

        // Return the matching Selenium 'By' object
        return type switch
        {
            "id" => By.Id(value),
            "css" => By.CssSelector(value),
            "xpath" => By.XPath(value),
            "name" => By.Name(value),
            _ => throw new ArgumentException($"Locator type '{type}' is not supported.")
        };
    }

    public void NavigateTo(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void Click(string locator)
    {
        // Use the helper method to find the element, then click it
        _driver.FindElement(GetBy(locator)).Click();
    }

    public void Type(string locator, string text)
    {
        var element = _driver.FindElement(GetBy(locator));
        element.Clear();
        element.SendKeys(text);
    }

    public string GetText(string locator)
    {
        return _driver.FindElement(GetBy(locator)).Text;
    }

    // This must return the underlying Selenium object
    public object GetDriver() => _driver;

    public void Quit()
    {
        _driver.Quit();
    }
}
