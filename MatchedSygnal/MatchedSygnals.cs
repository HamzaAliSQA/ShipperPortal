using Allure.Net.Commons;
using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

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

            await Task.Delay(10000);
            await bp.Click(page, "a[href='/lanes/matches/']", "Matched Sygnal Tab");
            
            var navigationTask = page.WaitForURLAsync("https://staging-carrier.trusygnal.com/lanes/matches/");
            await navigationTask;

            await bp.Wait(2000);

            //For Search
            extent.ChildLog("MatchedSygnal:Search");
            await bp.SimpleClick(page, "//label[text()='Search']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Search']/parent::div//following-sibling::div//input", "new york", "Search");

            //For Origin
            extent.ChildLog("MatchedSygnal:Origin");
            await bp.SimpleClick(page, "//label[text()='Origin']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Origin']/parent::div//following-sibling::div//input", "new york", "Origin");

            //For Destionation
            extent.ChildLog("MatchedSygnal:Destination");
            await bp.SimpleClick(page, "//label[text()='Destination']/parent::div//following-sibling::div//input");
            await bp.Write(page, "//label[text()='Destination']/parent::div//following-sibling::div//input", "los angeles", "Destination");

            string svgPathSelector = "path[d='M9.875 7.5a2.375 2.375 0 1 1-4.75 0a2.375 2.375 0 0 1 4.75 0']";

            try
            {
                // Wait for at least one SVG path element to be present in the DOM
                await page.WaitForSelectorAsync(svgPathSelector);

                // Query for all SVG path elements matching the selector
                var svgPathElements = await page.QuerySelectorAllAsync(svgPathSelector);

                if (svgPathElements.Count > 0)
                {
                    Console.WriteLine($"Found {svgPathElements.Count} SVG path elements. Clicking the first one.");

                    // Click the first SVG path element
                    await svgPathElements[0].ClickAsync();
                   /* await bp.Click(page, "//button[text()='Connect']", "ConnectButton");
                    
                    string reqbtnLoc = "//button[text()=' Requested']";
                    await page.WaitForSelectorAsync(reqbtnLoc);
                    await bp.Click(page, reqbtnLoc, "RequestButton");

                    await bp.Click(page, "//button[text()='Yes']", "CancelButton");*/
                }
                else
                {
                    Console.WriteLine("No SVG path elements found");
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("SVG path elements not found within the timeout period");
            }
            /*
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
            */
        }
    }
}
