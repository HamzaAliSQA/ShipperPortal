using Allure.Net.Commons;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Allure
    {
        public async Task TakeScreenshotAsync(IPage page, string stepDetail)
        {
            string directoryPath = @"E:\SeleniumPractice\ShipperPortal\ScreenShot\";
            Directory.CreateDirectory(directoryPath);  // Create the directory if it doesn't exist

            string path = Path.Combine(directoryPath, stepDetail + ".png");

            await page.ScreenshotAsync(new PageScreenshotOptions { Path = path });

            AllureLifecycle.Instance.AddAttachment(stepDetail, "image/png", path);
        }
    }
}
