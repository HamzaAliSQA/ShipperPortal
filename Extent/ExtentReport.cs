using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
        public static string pathWithFileNameExtension;
        public void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"D:\Projects\UpdatedProject\CarrierPortal\CarrierPortal\ScreenShot\" + "_" + testcase;

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }

        public async Task TakeScreenshot(IPage page, Status status, string stepDetail)
        {
            string path = @"D:\Projects\UpdatedProject\CarrierPortal\CarrierPortal\ScreenShot\" + stepDetail;
            pathWithFileNameExtension = @path + ".png";
            await page.Locator("body").ScreenshotAsync(new LocatorScreenshotOptions { Path = pathWithFileNameExtension });
            TestContext.AddTestAttachment(pathWithFileNameExtension);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public void ParentLog(string Pnode)
        {
            exParentTest = extentReports.CreateTest(Pnode);
        }
        public void ChildLog(string Childlog)
        {
            exChildTest = exParentTest.CreateNode(Childlog);
        }
        public void flush()
        {
            extentReports.Flush();
        }
    }
}
