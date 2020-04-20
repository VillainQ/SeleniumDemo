using LuxoftDemo.PageObjects;
using LuxoftDemo.Scenarios;
using TechTalk.SpecFlow;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace LuxoftDemo.Tests
{
    [Binding]
    public class LoginSteps : Cleanup, IClassFixture<DependencySetupFixture>
    {
        private readonly ITestScenario<CookiesPage> TestScenario;
        public LoginSteps(DependencySetupFixture fixture)
        {
            TestScenario = fixture.ServiceProvider.GetService<ITestScenario<CookiesPage>>();
        }

        [Given(@"I am on Ubs main page on (.*) with (.*)")]
        public void GivenIAmOnUbsMainPage(string browser, string language)
        {
            TestScenario.Initialise(browser, language);
            TestScenario.ScenarioActions.AcceptAllCookies();
        }

        [Given(@"I have selected Ubs safe in Login menu")]
        public void GivenIHaveSelectedUbsSafeInLoginMenu()
        {
            new HomePage().OpenLoginMenu();
            new LoginPage().SelectUbsSafe();
        }
        
        [When(@"I press Continue")]
        public void WhenIPressContinue()
        {
            new LoginPage().SafeLoginContinue();
        }
        
        [Then(@"validation with empty contact number will be shown\.")]
        public void ThenValidationWithEmptyContactNumberWillBeShown_()
        {
            new LoginPage().EmptyContactNumberValidationDisplayed();
        }
    }
}
