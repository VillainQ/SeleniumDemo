using Common;
using OpenQA.Selenium;

namespace LuxoftDemo.PageObjects
{
    public abstract class Page
    {
        protected IWebDriver Driver = DriverFactory.Driver;
    }
}
