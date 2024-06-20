using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class CompanyProfile
    {
        ExtentReport extent = new ExtentReport();
        Basepage bp = new Basepage();
        public async Task C_Profile(IPage page)
        {
            extent.ParentLog("Profile");
            extent.ChildLog("Comapny Profile Page");
            await bp.SimpleClick(page, "//span/div[text()='h']");
            //For Company Profile view
            await bp.Click(page, "//ul/li/div[text() ='Company Profile']","Company Profile");

            await Task.Delay(3000);
            await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            // Click the div
            await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");


            //For Edit Button
            extent.ChildLog("Edit Button");
            await bp.Click(page, "//div/button[text()='Edit']","Edit Button");

            //For Company Name
            extent.ChildLog("Company Name");
            await bp.SimpleClick(page, "//label[text()='Company Name']/parent::div/div");
            await bp.Write(page, "//label[text()='Company Name']/parent::div/div/input","ABCD","Company Name");

            //For Email
            extent.ChildLog("Email");
            await bp.SimpleClick(page, "//label[text()='Email']/parent::div/div");
            await bp.Write(page, "//label[text()='Email']/parent::div/div/input", "Test@test.com", "Email");

            //For Contact
            extent.ChildLog("Contact");
            await bp.SimpleClick(page, "//label[text()='Contact']/parent::div/div");
            await bp.Write(page, "//label[text()='Contact']/parent::div/div/input","1234567","Contact");

            //For Annual Spend
            extent.ChildLog("Annual Spend");
            await bp.SimpleClick(page, "//label[text()='Annual Spend']/parent::div/div");
            await bp.Type(page, "//label[text()='Annual Spend']/parent::div/div/input", "2010", "Annual Spend");

            //Address
            extent.ChildLog("Address");
            await bp.SimpleClick(page, "//label[text()='Address']/parent::div/div");
            await bp.Write(page, "//label[text()='Address']/parent::div/div/input", "Testing Area F/32 Pakistan", "Address");


            //For Save Button
            extent.ChildLog("Save Button");
            await bp.SimpleClick(page, "//div/button[text()='Save']");

        }
    }
}
