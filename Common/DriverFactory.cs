using System;
using System.Globalization;
using System.Threading;
using Common.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Common
{
    public static class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> WebDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver Driver => WebDriver.Value;

        public static void Start(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                     FirefoxDriverService geckoService = FirefoxDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                    geckoService.Host = "::1";
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AcceptInsecureCertificates = true;
                    WebDriver.Value = new FirefoxDriver(geckoService, firefoxOptions);
                    WebDriver.Value.Manage().Cookies.DeleteAllCookies();
                    break;
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddUserProfilePreference("browser.download.folderList", 2);
                    options.AddUserProfilePreference("browser.download.manager.showWhenStarting", false);
                    options.AddUserProfilePreference("browser.helperApps.neverAsk.saveToDisk", "application/csv");
                    options.AddUserProfilePreference("pdfjs.disabled", true);
                    options.AddArguments("--start-maximized");
                    options.Proxy = null;
                    WebDriver.Value = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
                    break;
                default:
                    throw new NotSupportedException(
                       string.Format(CultureInfo.CurrentCulture, "Driver {0} is not supported", browserType));
            }
            MaximizeWindow(browserType);
        }

        private static void MaximizeWindow(BrowserType browserType)
        {
            if (browserType != BrowserType.Chrome)
            {
                WebDriver.Value.Manage().Window.Maximize();
            }
        }

        public static void Stop()
        {
            WebDriver.Value.Quit();
        }

        public static void GoToUrl(string url)
        {
            WebDriver.Value.Navigate().GoToUrl(url);
            WebDriver.Value.WaitForAjax();
        }
    }
}
