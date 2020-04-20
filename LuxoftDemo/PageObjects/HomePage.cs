using Common;
using LuxoftDemo.Helpers;
using LuxoftDemo.Models;
using OpenQA.Selenium;

namespace LuxoftDemo.PageObjects
{
    public class HomePage : Page
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(HomePage));

        private readonly By MainHeaderTitle = By.ClassName("header__hlTitle");
        private readonly By LoginMenuButton = By.XPath("//span[text()='UBS logins']");

        public string GetMainHeaderTitle()
        {
            this.Driver.WaitForElementToBeVisible(MainHeaderTitle);
            var text = this.Driver.FindElement(MainHeaderTitle).Text;
            Logger.Info($"Header Text:{text}");
            return text;
        }

        public void SwitchLanguage(Language lang)
        {
            By LanguageSwitch = By.XPath($"//*[@lang='{lang.ToDescription()}']");

            this.Driver.WaitForElementToBeVisible(LanguageSwitch);
            this.Driver.FindElement(LanguageSwitch).Click();
            Logger.Info("Switch language to german");
        }

        public void OpenLoginMenu()
        {
            this.Driver.WaitForElementToBeVisible(LoginMenuButton);
            this.Driver.FindElement(LoginMenuButton).Click();
            Logger.Info("Open login menu");
        }

        public HomePage OpenMenu(MenuItems item)
        {
            this.Driver.FindElement(By.LinkText(item.ToString())).Click();
            Logger.Info($"Open {item} menu");
            return this;
        }

        public MeetUsPage SelectSubMenuItem(CarrierMenuItems item)
        {
            this.Driver.WaitForElementToBeVisible(By.LinkText(item.ToDescription()));
            this.Driver.FindElement(By.LinkText(item.ToDescription())).Click();
            Logger.Info($"Open {item} submenu");
            return new MeetUsPage();
        }
    }
}
