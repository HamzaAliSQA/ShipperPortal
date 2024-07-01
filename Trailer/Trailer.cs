using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Trailer
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task CP_Trailer(IPage page)
        {
            extent.ParentLog("Company Profile:Trailers");
         //   extent.ChildLog("Trailers");
            await bp.Wait(10000);
          //  await bp.SimpleClick(page, "//span/div[text()='h']");
            //For Company Profile view
          //  await bp.Click(page, "//ul/li/div[text() ='Company Profile']", "Company Profile");

            //await Task.Delay(3000);
         //   await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            // Click the div
         //   await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");
           
            //for Trailers Tab
            extent.ChildLog("Trailers Tab");
            await bp.Click(page, "//div[contains(@class,'MuiTabs-scroller')]/div/button[text()='Trailers ']", "TrailersTab");

            //For Edit Button
            extent.ChildLog("Edit Button");
            await bp.Click(page, "//div/button[text()='Edit']", "Edit Button");

            await bp.Wait(5000);
            //For Reefer
            await bp.Click(page, "//h5[text()='Reefer']//parent::div", "Reefer");

            //For Flatbed

            //await bp.Click(page, "//span[text() ='Flatbed']","Flatbed Checkbox");

            //For Van
           // await bp.Click(page, "//span[text() ='van']", "Van checkbox");

            //For Save Button
            extent.ChildLog("Save Button");
            await bp.Click(page, "//div/button[text()='Save']", "Trailers:SaveButton");

        }
    }
}
