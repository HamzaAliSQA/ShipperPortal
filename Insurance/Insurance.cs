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
       //     extent.ChildLog("Insurance");
            await bp.Wait(10000);
      //    await bp.SimpleClick(page, "//span/div[text()='h']");
            //For Company Profile view
      //      await bp.Click(page, "//ul/li/div[text() ='Company Profile']", "Company Profile");

            //await Task.Delay(3000);
      //      await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            // Click the div
       //    await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            //for Insurance Tab
            extent.ChildLog("Insurance Tab");
            await bp.Click(page, "//div[contains(@class,'MuiTabs-scroller')]/div/button[text()='Insurance']","InsuranceTab");

            await bp.Wait(6000);
            //For Cargo
            await bp.SimpleClick(page, "//label[text() ='Cargo']/following-sibling::div/input");
            await bp.Write(page, "//label[text() ='Cargo']/following-sibling::div/input","60000","Cargo");

            //For Save Button
            extent.ChildLog("Profile:Save Button");
            await bp.Click(page, "//div/button[text()='Save']", "Profile:SaveButton");
        }
    }
}
