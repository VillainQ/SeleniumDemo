using Common;
using OpenQA.Selenium;

namespace LuxoftDemo.PageObjects
{
    public class MeetUsPage : Page
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(MeetUsPage));
        private readonly By HeadlineInfo = By.XPath("//p[text()='Take a look behind the scenes on our careers blog']");

        public void IsOnMeetUsPage()
        {
            this.Driver.WaitForElementToBeVisible(HeadlineInfo);
            Logger.Info("Headline displayed");
        }
    }
}
