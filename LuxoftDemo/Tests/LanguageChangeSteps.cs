using LuxoftDemo.Models;
using LuxoftDemo.PageObjects;
using TechTalk.SpecFlow;
using Xunit;

namespace LuxoftDemo.Tests
{
    [Binding]
    public class LanguageChangeSteps
    {
        [Given(@"Selected language is english")]
        public void GivenSelectedLanguageIsEnglish()
        {
            const string ExpectedEnglishTitle = "Global topics";
            var actualEnglishTitle = new HomePage().GetMainHeaderTitle();
            Assert.Equal(ExpectedEnglishTitle, actualEnglishTitle);
        }

        [When(@"I click language switch")]
        public void WhenIClickLanguageSwitch()
        {
            new HomePage().SwitchLanguage(Language.De);
        }

        [Then(@"Page language will change to DE")]
        public void PageLanguageWillChangeToDe()
        {
            const string ExpectedGermanTitle = "Globale Themen";
            var actualGermanTitle = new HomePage().GetMainHeaderTitle();
            Assert.Equal(ExpectedGermanTitle, actualGermanTitle);
        }
    }
}
