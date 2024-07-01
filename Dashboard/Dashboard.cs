using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Dashboard
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        Sygnal addsygnal = new Sygnal();  
        public async Task DashboardFeature(IPage page)
        {
            extent.ParentLog("Dashboard");
            extent.ChildLog("Dashboard:MySygnal");

            await bp.Wait(10000);            
            await MySygnal(page);
            extent.ChildLog("Dashboard:MatchedSygnal");
            await MatchedSygnal(page);
            await page.EvaluateAsync(@"window.scrollBy(0, 1500);");
            extent.ChildLog("Dashboard:DownUpload Feature");
            await DownUploadFile(page);
            await bp.Wait(3000);
            await bp.Click(page, "//div[contains(@class,'MuiCardHeader-action')]/button","logClose");
            extent.ChildLog("Dashboard:AddSygnal");
            await addsygnal.Addsygnal(page);
            extent.ChildLog("Dashboard:Search Sygnal");
            await addsygnal.SearchSygnals(page,addsygnal.origin,addsygnal.dest,addsygnal.TT,addsygnal.Vol,addsygnal.VF);
            extent.ChildLog("Dashboard:Update Sygnal");
            await addsygnal.UpdateSygnal(page);
            extent.ChildLog("Dashboard:Delete Sygnal");
            await addsygnal.DeleteSygnal(page);
        }

        //>>>>>In Class Funtions for different Features

        public async Task MySygnal(IPage page)
        {
            //For Origin
            extent.ChildLog("MySygnals:Origin");
            await bp.SimpleClick(page, "//h2[text()='My Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Origin']/following-sibling::div/input");
            await bp.Write(page, "//h2[text()='My Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Origin']/following-sibling::div/input", "New York", "Origin");

            //For Destionation
            extent.ChildLog("MySygnals:Destination");
            await bp.SimpleClick(page, "//h2[text()='My Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Destination']/following-sibling::div/input");
            await bp.Write(page, "//h2[text()='My Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Destination']/following-sibling::div/input", "Los Angeles", "Destination");

            //For Trailer Type
            extent.ChildLog("MySygnals:Trailer Type");
            await bp.SimpleClick(page, "//h2[text()='My Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Trailer Type']/following-sibling::div");
            await bp.Click(page, "//li[text()='Reefer']", "SygnalsTrailerType");
        }
        public async Task MatchedSygnal(IPage page)
        {
            //For Origin
            extent.ChildLog("MatchedSygnals:Origin");
            await bp.SimpleClick(page, "//h2[text()='Matched Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Origin']/following-sibling::div/input");
            await bp.Write(page, "//h2[text()='Matched Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Origin']/following-sibling::div/input", "New York", "Origin");

            //For Destionation
            extent.ChildLog("MatchedSygnals:Destination");
            await bp.SimpleClick(page, "//h2[text()='Matched Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Destination']/following-sibling::div/input");
            await bp.Write(page, "//h2[text()='Matched Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Destination']/following-sibling::div/input", "Los Angeles", "Destination");

            //For Trailer Type
            extent.ChildLog("MatchedSygnals:Trailer Type");
            await bp.SimpleClick(page,"//h2[text()='Matched Sygnals']/parent::div/following-sibling::div/div/div/label[text()='Trailer Type']/following-sibling::div");
            await bp.Click(page, "//li[text()='Reefer']", "SygnalsTrailerType");
            
        }

        public async Task DownUploadFile(IPage page)
        {
            await bp.Click(page, "//a[@download='carrier-sygnal-import-template.xlsx']", "sampledownload");
            // Locate the file input element
            var fileInput = page.Locator("input[type='file']");

            // Upload the file
            await fileInput.SetInputFilesAsync("C:/Users/Humza Ali/Downloads/carrier-sygnal-import-template.xlsx");

            await bp.Click(page, "//span[text() = 'Update existing sygnals']/preceding-sibling::span//span", "UpdateSygnals");

            await bp.Click(page, "//div/following-sibling::div//button[text() ='Yes']", "Confirmation");

            string filePath = "C:/Users/Humza Ali/Downloads/carrier-sygnal-import-template.xlsx";
            string[] lines = File.ReadAllLines(filePath);
            string fileContent = File.ReadAllText(filePath);

            // Split the content into rows
            string[] rows = fileContent.Split('\n');

            // Check if there are at least two rows
            if (rows.Length >= 2)
            {
                // Extract values from the second row
                string[] secondRowValues = rows[1].Split(',');

                // Replace values in the first row with values from the second row
                string[] firstRowValues = rows[0].Split(',');
                for (int i = 0; i < Math.Min(firstRowValues.Length, secondRowValues.Length); i++)
                {
                    firstRowValues[i] = secondRowValues[i];
                }

                // Join the modified first row with other rows
                rows[0] = string.Join(",", firstRowValues);
                string modifiedContent = string.Join("\n", rows);

                // Write the modified content back to the file
                File.WriteAllText(filePath, modifiedContent);
            }
            else
            {
                Console.WriteLine("File does not have at least two rows.");
            }
        }
    }
}
