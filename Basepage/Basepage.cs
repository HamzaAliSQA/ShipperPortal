using AventStack.ExtentReports;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Basepage 
    {
        Allure allure = new Allure();
        ExtentReport extent = new ExtentReport();
        public async Task Goto(IPage page, string url)
        {
            await page.GotoAsync(url);
            await extent.TakeScreenshot(page, Status.Pass, "Enter_URL");
            //await allure.TakeScreenshotAsync(page,"URL");

        }
        public async Task Write(IPage page, string loc, string text, string stepdetail)
        {
            var locator = await page.QuerySelectorAsync(loc);
            if (locator != null) 
            {
                await locator.FillAsync(text);
                await extent.TakeScreenshot(page,Status.Pass,stepdetail);
                //await allure.TakeScreenshotAsync(page, stepdetail);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public async Task Type(IPage page, string loc, string text, string stepdetail)
        {
            var locator = await page.QuerySelectorAsync(loc);
            if (locator != null)
            {
                await locator.TypeAsync(text);
                await extent.TakeScreenshot(page, Status.Pass, stepdetail);
                //await allure.TakeScreenshotAsync(page, stepdetail);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public async Task SimpleClick(IPage page, string loc)
        {
            var locator = await page.QuerySelectorAsync(loc);
            if (locator != null)
            {
                await locator.ClickAsync();
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        public async Task Click(IPage page, string loc, string stepdetail)
        {
            var locator = await page.QuerySelectorAsync(loc);
            if (locator != null)
            {
                await locator.ClickAsync();
                //await allure.TakeScreenshotAsync(page,stepdetail);
                await extent.TakeScreenshot(page,Status.Pass,stepdetail);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        public async Task Assertion(IPage page,string selector, string expText, string stepdetail)
        {
            var element = await page.WaitForSelectorAsync(selector);
            if (element == null)
            {
                Assert.Fail($"No element found with selector: {selector}");
                return; // Ensure we do not proceed further if the element is null
            }

            var actualText = await element.InnerTextAsync();
            if (actualText == expText)
            {
                Assert.That(actualText, Is.EqualTo(expText), "Expected text matches the actual text.");
                await extent.TakeScreenshot(page, Status.Pass, stepdetail);
                //await allure.TakeScreenshotAsync(page,expText);
            }
            else
            {
                Assert.That(actualText, Is.Not.EqualTo(expText), "Expected text does not match the actual text.");
            }
        }

        public async Task Keyboardaction(IPage page, string action)
        {
            if (action == "up")
            {
                await page.Keyboard.PressAsync("ArrowUp");
            }
            else if (action == "down")
            {
                await page.Keyboard.PressAsync("ArrowDown");
            }
            else if (action == "tab")
            {
                await page.Keyboard.PressAsync("Tab");
            }
            else if (action == "enter")
            {
                await page.Keyboard.PressAsync("Enter");
            }
        }

        public async Task Wait(int wait)
        {
            await Task.Delay(wait);
        }
    }
}
