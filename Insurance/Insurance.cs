using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Insurance
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task CP_Insurance(IPage page)
        {
            extent.ParentLog("Company Profile:Insurance");
            extent.ChildLog("Insurance");
            await bp.SimpleClick(page, "//span/div[text()='h']");
            //For Company Profile view
            await bp.Click(page, "//ul/li/div[text() ='Company Profile']", "Company Profile");

            //await Task.Delay(3000);
            await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            // Click the div
            await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            //For Edit Button
            extent.ChildLog("Edit Button");
            await bp.Click(page, "//div/button[text()='Edit']", "Edit Button");

            //for Insurance Tab
            extent.ChildLog("Insurance Tab");
            await bp.Click(page, "//div[contains(@class,'MuiTabs-scroller')]/div/button[text()='Insurance ']","InsuranceTab");

            //for screen scroll down
            await page.EvaluateAsync(@"window.scrollBy(0, 1000);");

            //For General Liability
            await bp.SimpleClick(page, "//label[text() ='General Liability']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='General Liability']/following-sibling::div/input","5434563","GeneralLiability");

            //For Umbrella
            await bp.SimpleClick(page, "//label[text() ='Umbrella']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='Umbrella']/following-sibling::div/input","45645","UmbrellaAmount");

            //For Workers Comp
            await bp.SimpleClick(page, "//label[text() ='Workers Compensation']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='Workers Compensation']/following-sibling::div/input", "45", "workersComp");

            //for Auto Liability
            await bp.SimpleClick(page, "//label[text() ='Auto Liability']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='Auto Liability']/following-sibling::div/input","60000","AutoLiability");

            //For Cargo
            await bp.SimpleClick(page, "//label[text() ='Cargo']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='Cargo']/following-sibling::div/input","11000000","Cargo");



        }
    }
}
