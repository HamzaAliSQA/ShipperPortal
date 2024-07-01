using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Services
    {
        Basepage bp = new Basepage();   
        ExtentReport extent = new ExtentReport();   
        public async Task service(IPage page)
        {
          //  extent.ParentLog("Profile");
          //  // extent.ChildLog("Comapny Profile Page");
          //  await Task.Delay(10000);
          //  await bp.SimpleClick(page, "//span/div[text()='d']");
          //  //For Company Profile view
          //  await bp.Click(page, "//ul/li/div[text() ='Company Profile']", "Company Profile");
          //
          //  await Task.Delay(3000);
          //  await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");
          //
          //  // Click the div
          //  await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");
          //
          //
          //  //For Edit Button
          //  extent.ChildLog("Edit Button");
          //  await bp.Click(page, "//div/button[text()='Edit']", "Edit Button");

            //Service Tab
            extent.ChildLog("Services Tab");
            await bp.Click(page, "//div[contains(@class,'MuiTabs-scroller')]/div/button[text()='Services ']", "Services Tab");

            //For Vegetable service
            extent.ChildLog("Serivce");
            await bp.Click(page, "//div[contains(@class,'MuiBox-root css-19nzcwv')]//p[text()='Vegetables']","VegetableService");

        }
    }
}
