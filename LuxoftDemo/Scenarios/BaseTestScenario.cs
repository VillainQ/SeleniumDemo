using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Common;
using Common.Browsers;
using LuxoftDemo.DependencyInjection;
using LuxoftDemo.Models;
using LuxoftDemo.PageObjects;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace LuxoftDemo.Scenarios
{
    public class BaseTestScenario : ITestScenario<CookiesPage>
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(BaseTestScenario));
        public CookiesPage ScenarioActions { get; set; }

        public BrowserType BrowserType { get; set; }

        public IWebDriver Driver { get; set; }

        private readonly string HomePageUrl;

        public BaseTestScenario(IOptions<UbsOptions> options)
        {
            HomePageUrl = options.Value.Uri;
        }

        public void Initialise(string browser, string language)
        {
            var browserType = MapBrowser(browser);
            var lang = MapLanguage(language);
            this.EnableLogging();
            Logger.Info(HomePageUrl);

            DriverFactory.Start(browserType);
            DriverFactory.GoToUrl(GetUrlWithLanguage(lang));

            this.ScenarioActions = new CookiesPage();
        }


        private BrowserType MapBrowser(string browser)
        {
            var Browser = BrowserType.Chrome;
            if (browser == "firefox")
                Browser = BrowserType.Firefox;
            return Browser;
        }

        private Language MapLanguage(string language)
        {
            var Language = Models.Language.En;

            if (language == "de")
                Language = Language.De;
            return Language;
        }

        private string GetUrlWithLanguage(Language lang)
        {
            switch (lang)
            {
                case Language.En:
                    return HomePageUrl + "global/en.html";
                case Language.De:
                    return HomePageUrl + "global/de.html";
                default:
                    throw new ArgumentOutOfRangeException(nameof(lang), lang, null);
            }
        }

        private void EnableLogging()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }

}
