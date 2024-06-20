using Allure.Net.Commons;
using Microsoft.Playwright;

namespace ShipperPortal
{
    public class MatchedSygnals 
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task Matched_sygnals(IPage page)
        {
            extent.ParentLog("Matched Sygnals");
            extent.ChildLog("Matched Sygnals Page");
            await bp.Click(page, "a[href='/lanes/matches/']", "Matched Sygnal");
            var navigationTask = page.WaitForURLAsync("https://staging-shipper.trusygnal.com/lanes/matches/");
            await navigationTask;

           // await bp.Wait(2000);

            await Origin(page);
            //For Destionation
            extent.ChildLog("Destination");
            await bp.SimpleClick(page, "//label[text()='Destination']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Destination']/parent::div//following-sibling::div//input", "United States", "Destination");

            //For Trailer Type
            extent.ChildLog("Trailer Type");
            await bp.SimpleClick(page, "//label[text()='Trailer Type']/following-sibling::div/div");
            await bp.Click(page, "//li[text()='Reefer']", "Trailer Type");

            //Dead Head
            extent.ChildLog("Dead Head");
            await bp.SimpleClick(page, "//div[contains(@class,'MuiGrid-root')]//input[@placeholder='Dead Head']");
            await bp.Write(page, "//div[contains(@class,'MuiGrid-root')]//input[@placeholder='Dead Head']", "2", "DeadHead");

            //For Volume
            extent.ChildLog("Volume");
            await bp.SimpleClick(page, "//label[text()='Volume']/following-sibling::div/input");
            await bp.Write(page, "//label[text()='Volume']/following-sibling::div/input", "3", "Volume");

            //For Frequency
            extent.ChildLog("Volume Frequency");
            await bp.SimpleClick(page, "//label[text()='Volume Frequency']/following-sibling::div/div");
            await bp.Click(page, "//li[text()= 'LPM']", "Volume Frequency");

            //For Status
            extent.ChildLog("Status");
            await bp.SimpleClick(page, "//label[text()='Status']/parent::div/div");
            await bp.Click(page, "//li[text()='Full Match']", "Status");

            //For Sort
            extent.ChildLog("Sort Column");
            await bp.SimpleClick(page, "//label[text()='Sort Column']/parent::div/div");
            await bp.Click(page, "//li[text()='Volume']", "Sort Column");

            //For SortBy
            extent.ChildLog("Sort By");
            await bp.SimpleClick(page, "//label[text()='SortBy']/parent::div/div");
            await bp.Click(page, "//li[text()='ASC']", "SortBy");

            await bp.Wait(4000);

        }
        //Origin  Function
        public async Task Origin(IPage page)
        {
            extent.ChildLog("Origin");
            await bp.SimpleClick(page, "//label[text()='Origin']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Origin']/parent::div//following-sibling::div//input", "Chester", "Origin");
        }

    }
}
