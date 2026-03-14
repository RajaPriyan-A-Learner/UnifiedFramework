using Deque.AxeCore.Selenium;
using Framework.Core.Interfaces;
using OpenQA.Selenium;
using System;

namespace Framework.Accessibility
{
    public class AxeScanner : IAccessibilityScanner
    {
        private readonly IWebDriver _driver;

        public AxeScanner(IWebDriver driver)
        {
            _driver = driver;
        }

        public void RunScan(string pageName)
        {
            var results = new AxeBuilder(_driver)
                .WithTags("wcag2a", "wcag2aa") // Standard compliance levels
                .Analyze();

            if (results.Violations.Length > 0)
            {
                // Professional logging for Lead SDETs
                foreach (var violation in results.Violations)
                {
                    Console.WriteLine($"[Accessibility Violation] ID: {violation.Id}");
                    Console.WriteLine($"Description: {violation.Description}");
                    Console.WriteLine($"Impact: {violation.Impact}");
                    Console.WriteLine($"Help URL: {violation.HelpUrl}");
                    Console.WriteLine("--------------------------------------------");
                }

                throw new Exception($"Accessibility check failed for '{pageName}' with {results.Violations.Length} violations.");
            }
        }
    }
}