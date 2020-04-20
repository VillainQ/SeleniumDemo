using Common;
using OpenQA.Selenium;

namespace LuxoftDemo.PageObjects
{
    public class CookiesPage: Page
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(HomePage));
        private readonly By AgreeAllCookiesButton = By.XPath("//span[text()='Agree to all']");
        private readonly By Iframe = By.TagName("iframe");


        public void AcceptAllCookies()
        {
            this.Driver.WaitForElementToBeVisible(Iframe);
            this.Driver.SwitchTo().Frame(0);

            this.Driver.WaitForElementToBeVisible(AgreeAllCookiesButton);
            this.Driver.FindElement(AgreeAllCookiesButton).Click();
            Logger.Info("Agree All Cookies Clicked");

            this.Driver.SwitchTo().DefaultContent();
        }
    }
}
