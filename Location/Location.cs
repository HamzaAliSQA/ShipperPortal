using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Location
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public string namevalue = "Testing Club";
        public async Task CP_Location(IPage page)
        {
            extent.ParentLog("Company Profile:Location");
           // extent.ChildLog("Location");
            await Task.Delay(10000);
          //  await bp.SimpleClick(page, "//span/div[text()='h']");
            //For Company Profile view
          //  await bp.Click(page, "//ul/li/div[text() ='Company Profile']", "Company Profile");

            //await Task.Delay(3000);
         //   await page.WaitForSelectorAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            // Click the div
         ///   await page.ClickAsync(".MuiBackdrop-root.MuiBackdrop-invisible.MuiModal-backdrop.css-xk0aud");

            extent.ChildLog("Locations Tab");
            await bp.Click(page, "//div[contains(@class,'MuiTabs-scroller')]/div/button[text()='Locations']","Location Tab");

            //For Adding new Location
            await bp.Click(page, "//button[text()='Add New Headquarters']", "Add Location");

            await bp.Wait(4000);

            //For State
            await bp.SimpleClick(page, "//label[text()='State']/parent::div/div/input");
            await bp.Write(page, "//label[text()='State']/parent::div/div/input","Alaska","State");
            await bp.Keyboardaction(page,"down");
            await bp.Keyboardaction(page, "enter");
            await bp.Wait(4000);

            //For City
            await bp.SimpleClick(page, "//label[text()='City']/parent::div/div/input");
            await bp.Write(page, "//label[text()='City']/parent::div/div/input", "Badger", "City");
            await bp.Keyboardaction(page, "down");
            await bp.Keyboardaction(page, "enter");

            //For Name
            
            await bp.SimpleClick(page, "//label[text()='Name']/parent::div/div/input");
            await bp.Write(page, "//label[text()='Name']/parent::div/div/input",namevalue,"Name");

            //For ZipCOde
            await bp.SimpleClick(page, "//label[text()='Zip Code']/parent::div/div/input");
            await bp.Write(page, "//label[text()='Zip Code']/parent::div/div/input","75660","Zipcode");

            //For Address
            await bp.SimpleClick(page,"//label[text()='Address']/parent::div/div/input");
            await bp.Write(page, "//label[text()='Address']/parent::div/div/input", "Testing Area f/23, Alaska","Address");

            //For HQ radio button
            await bp.Click(page, "//div[@class='MuiGrid-root MuiGrid-item MuiGrid-grid-xs-4 css-1udb513']/div/p[1]", "HQ Checkbox");

            //For Save Button
            await bp.Click(page, "//button[text()='Save']","save button");

            //for screen scroll down
            await page.EvaluateAsync(@"window.scrollBy(0, 1000);");

            await Task.Delay(4000);

            //For Assertion
            extent.ChildLog("Location:Assertion");
            await bp.Assertion(page, $"//div[contains(@class,'MuiDataGrid-row')]/div[text()='{namevalue}']",namevalue,"record Found");

            //For Updation 
            extent.ChildLog("Location:Updation");
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]/div[text()='{namevalue}']/following-sibling::div[6]/div/div[1]","RecordUpdate");
            await bp.SimpleClick(page, "//label[text()='Address']/parent::div/div/input");
            await bp.Write(page, "//label[text()='Address']/parent::div/div/input","Testing address Updation","Address update");
            await bp.SimpleClick(page, "//button[text()='Update']");

            //For Deletion 
            extent.ChildLog("Location:Deletion");
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]/div[text()='{namevalue}']/following-sibling::div[6]/div/div[2]","DeletioBtn");
            await bp.Click(page, "//button[text()='Yes']", "ConfirmBtn");
        }
    }
}
