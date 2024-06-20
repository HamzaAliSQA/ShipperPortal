using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class AddSygnal
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task AddnewSygnal(IPage page)
        {
            extent.ParentLog("Add new Sygnal");
            extent.ChildLog("New Sygnal");
            await bp.Click(page, "a[href='/lanes/']", "Sygnals");
            var navigationTask = page.WaitForURLAsync("https://staging-shipper.trusygnal.com/lanes/");
            await navigationTask;

            //For Add sygnal
           // await bp.Click(page, "//button[text()='Add Sygnal']", "AddSygnal Button");
            var origin = "Italy";
            /*
            //For Origin
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin']/following-sibling::div/input",origin,"Origin");
            await bp.Wait(5000);
            await bp.Click(page, $"//input[contains(@value,'{origin}')]/parent::div/parent::div/following-sibling::div/li[1]", "originselect");

            //For Destination
            var dest = "austin";
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination']/following-sibling::div/input",dest,"Destination");
            await bp.Wait(5000);
            await bp.Click(page,$"//input[contains(@value,'{dest}')]/parent::div/parent::div/following-sibling::div/li[1]","DestinationSelect");

            //For Volume
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume']/following-sibling::div/input", "30", "NewSygnalVolume");

            //For Volume Frequency
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume Frequency']/following-sibling::div");
            await bp.Click(page, "//li[@data-value='week' and text()='LPW']", "SygnalsFrequency");

            //For Select reefer
            await bp.Click(page, "//span[text()='Reefer']", "Reefer");

            //FOr Save Button 
            await bp.Click(page, "//button[text()='Save']", "SaveButton");
            */
            //For last inserted record updation
            await bp.SimpleClick(page, "//label[text()='Origin']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Origin']/parent::div//following-sibling::div//input", origin, "search origin");
            await bp.Wait(3000);
            //For Update pencil
            await bp.SimpleClick(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{origin}')]/following-sibling::div[5]/div/button[1]");

            //For Van click
            await bp.Click(page, "//span[text()='van']", "van checkbox");

            //for Update Button
            await bp.Click(page, "//button[text()='Update']","Update Button");

            //For Deletion
            await bp.SimpleClick(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{origin}')]/following-sibling::div[5]/div/button[3]");
            await bp.Click(page, "//button[text()='Yes']","DeleteRecord");
        }
    }
}
