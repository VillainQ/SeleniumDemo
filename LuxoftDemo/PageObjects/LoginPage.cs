using Common;
using OpenQA.Selenium;

namespace LuxoftDemo.PageObjects
{
    public class LoginPage : Page
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(HomePage));
        private readonly By UbsSafeHref = By.LinkText("UBS Safe");
        private readonly By ContinueButton = By.Id("AuthGetContractNrDialog_submit");
        private readonly By EmptyContactNumberValidationMessageLi = By.XPath("//li[text()='Enter your contract number.']");

        public LoginPage SelectUbsSafe()
        {
            this.Driver.WaitForElementToBeVisible(UbsSafeHref);
            this.Driver.FindElement(UbsSafeHref).Click();
            Logger.Info("UbsSafe Clicked");

            return this;

        }

        public LoginPage SafeLoginContinue()
        {
            this.Driver.WaitForElementToBeVisible(ContinueButton);
            this.Driver.FindElement(ContinueButton).Click();
            Logger.Info("Continue Clicked");

            return this;
        }

        public void EmptyContactNumberValidationDisplayed()
        {
            this.Driver.WaitForElementToBeVisible(EmptyContactNumberValidationMessageLi);
            Logger.Info("Empty contact number validation displayed");
        }
    }
}
