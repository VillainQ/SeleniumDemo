using LuxoftDemo.Models;
using LuxoftDemo.PageObjects;
using TechTalk.SpecFlow;

namespace LuxoftDemo.Tests
{
    [Binding]
    public class DashboardNavigationSteps
    {
        [When(@"I select about as in carrier dropdown")]
        public void WhenISelectAboutAsInCarrierDropdown()
        {
            new HomePage()
                .OpenMenu(MenuItems.Careers)
                .SelectSubMenuItem(CarrierMenuItems.MeetUs);
        }
        
        [Then(@"I will be redirected to about us page")]
        public void ThenIWillBeRedirectedToAboutUsPage()
        {
            new MeetUsPage().IsOnMeetUsPage();
        }
    }
}
