using Common.Browsers;
using OpenQA.Selenium;

namespace LuxoftDemo.Scenarios
{
    public interface ITestScenario<out TAction>
    {
        TAction ScenarioActions { get; }

        BrowserType BrowserType { get; set; }

        IWebDriver Driver { get; set; }

        void Initialise(string browserType, string language);
    }
}
