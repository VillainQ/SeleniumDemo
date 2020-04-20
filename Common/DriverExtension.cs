using System;
using Common.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Common
{
    public static class DriverExtension
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(DriverExtension));

        public static void WaitForElementToBeVisible(this IWebDriver driver, By elementlocator, double timeout = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
                .Until(ExpectedConditions.ElementIsVisible(elementlocator));
        }

        public static void WaitForAjax(this IWebDriver webDriver, double timeout = 30)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout)).Until(
                    driver =>
                    {
                        var javaScriptExecutor = driver as IJavaScriptExecutor;
                        return javaScriptExecutor != null
                               && (bool)javaScriptExecutor.ExecuteScript("return window.jQuery != undefined && jQuery.active == 0");
                    });
            }
            catch (AjaxTimeoutException ex)
            {
                Logger.Error($"Error occured during waiting for ajax's end: {ex.Message}", ex);
                throw;
            }
        }

    }
}
