using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Sygnals
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task sygnals(IPage page)
        {
            extent.ParentLog("Sygnals");
            extent.ChildLog("Sygnals Page");
            await bp.Click(page, "a[href='/lanes/']", "Sygnals");
            var navigationTask = page.WaitForURLAsync("https://staging-shipper.trusygnal.com/lanes/");
            await navigationTask;

            //await bp.Wait(2000);
            //For Origin
            extent.ChildLog("Origin");
            await bp.SimpleClick(page, "//label[text()='Origin']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Origin']/parent::div//following-sibling::div//input", "Chester", "SygnalsOrigin");

            //For Destionation
            extent.ChildLog("Destination");
            await bp.SimpleClick(page, "//label[text()='Destination']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Destination']/parent::div//following-sibling::div//input", "United States", "SygnalsDestination");

            //For Trailer Type
            extent.ChildLog("Trailer Type");
            await bp.SimpleClick(page, "//label[text()='Trailer Type']/following-sibling::div/div");
            await bp.Click(page, "//li[text()='Reefer']", "SygnalsTrailerType");

            //Dead Head
            extent.ChildLog("Dead Head");
            await bp.SimpleClick(page, "//div[contains(@class,'MuiGrid-root')]//input[@placeholder='Dead Head']");
            await bp.Write(page, "//div[contains(@class,'MuiGrid-root')]//input[@placeholder='Dead Head']", "2", "SygnalsDeadHead");

            //For Volume
            extent.ChildLog("Volume");
            await bp.SimpleClick(page, "//label[text()='Volume']/following-sibling::div/input");
            await bp.Write(page, "//label[text()='Volume']/following-sibling::div/input", "3", "SygnalsVolume");

            //For Frequency
            extent.ChildLog("Volume Frequency");
            await bp.SimpleClick(page, "//label[text()='Volume Frequency']/following-sibling::div/div");
            await bp.Click(page, "//li[text()= 'LPM']", "SygnalsFrequency");
        }
    }
}
