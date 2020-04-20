using System;

using Common;
using Common.Utilities;

namespace LuxoftDemo.Tests
{
    public class Cleanup : IDisposable
    {
        public void Dispose()
        {
            new ScreenshotUtil().MakePageScreenshot();

            DriverFactory.Stop();
        }
    }
}
