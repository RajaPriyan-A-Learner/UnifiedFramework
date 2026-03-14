using Framework.Core.Enums;
using Framework.Tests.BaseTests;
using NUnit.Framework;

[TestFixture(BrowserType.Chrome)]
[TestFixture(BrowserType.Edge)]
public class WcagTests(BrowserType browserType) : AccessibilityBaseTest(browserType)
{
    [Test]
    public void VerifyHomeAccessibility()
    {
        UI.NavigateTo("https://www.wikipedia.org/");
        Scanner.RunScan("Wikipedia Home");
    }
}