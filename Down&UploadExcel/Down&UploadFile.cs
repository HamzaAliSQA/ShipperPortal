using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Down_UploadFile
    {
        Basepage bp = new Basepage();  
        public async Task DownUploadFile(IPage page)
        {
            await Task.Delay(10000);
            //await bp.Click(page, "//li/a/div/following-sibling::div/p[text()='Sygnals']", "DownUpload Page");
            
           // var navigationTask = page.WaitForURLAsync("https://staging-shipper.trusygnal.com/lanes/");
            //await navigationTask;

            await bp.Click(page, "//a[@download='carrier-sygnal-import-template.xlsx']", "sampledownload");
            /*var ClickSammple = await page.QuerySelectorAsync("//a[@download='shipper-sygnal-import-template.xlsx']");


            var downloadsample = await page.QuerySelectorAsync("//a[@href='/import-files/shipper-sygnal-import-template.xlsx']");

            if (downloadsample != null)
            {
                await downloadsample.ClickAsync();
                await Task.Delay(20000);
                // Click the download button to initiate the download
                Console.WriteLine("Downloaded Succesfully!!");
            }
            else
            {
                Console.WriteLine("Download button not found");
                return;
            }
            */
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
