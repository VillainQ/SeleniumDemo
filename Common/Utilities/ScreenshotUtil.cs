using System;
using System.IO;
using System.Reflection;
using log4net;
using OpenQA.Selenium;

namespace Common.Utilities
{
    public class ScreenshotUtil
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ScreenshotUtil));

        private readonly string PathForScreenshots = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public void MakePageScreenshot()
        {
                try
                {
                    Screenshot ss = ((ITakesScreenshot)DriverFactory.Driver).GetScreenshot();
                    var direcotryPath = $"{PathForScreenshots}/images";
                    Directory.CreateDirectory(direcotryPath);

                    var screenshotPath = $"{direcotryPath}/{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
                    ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                    Logger.Info($"Screenshot: {new Uri(screenshotPath)}");
                }
                catch (Exception e)
                {
                    DriverFactory.Stop();
                    throw new Exception(e.ToString());
                }            
        }
    }
}
