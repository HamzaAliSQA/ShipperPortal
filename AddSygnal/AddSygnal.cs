using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class Sygnal
    {
        Basepage bp = new Basepage();
        Down_UploadFile DU_f = new Down_UploadFile();
        ExtentReport extent = new ExtentReport();
        public string origin = "Italy";
        public string OriginDH = "30";
        public string DestinationDH = "30";
        public string dest = "Austin";
        public string TT = "Reefer";
        public string Vol = "30";
        public string VF = "LPW";
        public async Task sygnal(IPage page)
        {
            extent.ParentLog("Add new Sygnal");
            extent.ChildLog("New Sygnal");
            await Task.Delay(20000);
            await bp.Click(page, "a[href='/lanes/']", "Sygnals");
            var navigationTask = page.WaitForURLAsync("https://staging-carrier.trusygnal.com/lanes/");
            await navigationTask;
            //await page.EvaluateAsync("document.body.style.zoom=0.8");
            //await Task.Delay(3000);
            await DU_f.DownUploadFile(page);
            await bp.Wait(4000);
            extent.ChildLog("Sygnal:AddSygnal");
            await Addsygnal(page);
            //For Search
            extent.ChildLog("Sygnal:Search");
            await SearchSygnals(page,origin,dest,TT,Vol,VF);
            await bp.Wait(2000);
            extent.ChildLog("Sygnal:UpdateSygnal");
            await UpdateSygnal(page);
            await bp.Wait(2000);
            extent.ChildLog("Sygnal:DeleteSygnal");
            await DeleteSygnal(page);
            await bp.Wait(9000);

        }

        //>>>>>>>>>>>>>>>>>>>>>>>>>IN CLASS FUNCTIONS FOR USE<<<<<<<<<<<<<<<<<<<<<<<<<
        public async Task Addsygnal(IPage page)
        {
            //For Add sygnal
            await bp.Click(page, "//button[text()='Add Sygnal']", "AddSygnal Button");
            

            //For Origin
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin']/following-sibling::div/input", origin, "Origin");
            await bp.Wait(5000);
            await bp.Click(page, $"//input[contains(@value,'{origin}')]/parent::div/parent::div/following-sibling::div/li[1]", "originselect");

            //For Origin DeadHaed
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin Dead Head']/following-sibling::div/input");
            await bp.Type(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Origin Dead Head']/following-sibling::div/input", OriginDH,"OriginDH");


            //For Destination
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination']/following-sibling::div/input", dest, "Destination");
            await bp.Wait(5000);
            await bp.Click(page, $"//input[contains(@value,'{dest}')]/parent::div/parent::div/following-sibling::div/li[1]", "DestinationSelect");

            //For Destination DeadHaed
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination Dead Head']/following-sibling::div/input");
            await bp.Type(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Destination Dead Head']/following-sibling::div/input", DestinationDH, "DestinationDH");

            //For Volume
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume']/following-sibling::div/input");
            await bp.Write(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume']/following-sibling::div/input", Vol, "NewSygnalVolume");

            //For Volume Frequency
            await bp.SimpleClick(page, "//h5[text()='Add New Sygnal']/following-sibling::div//label[text()='Volume Frequency']/following-sibling::div");
            await bp.Click(page, $"//li[text()='{VF}']", "SygnalsFrequency");

            //For Select reefer
            await bp.Click(page, $"//div[contains(@class,'MuiBox-root css-19nzcwv')]//p[text()='{TT}']", "Reefer");

            //For All-in
            await bp.Click(page, "//div[contains(@class,'MuiBox-root css-180vfpl')]/div/p[text()='All-in'][1]","All-in");

            //for 3 months
            await bp.SimpleClick(page, "//label[text()='03 Months Rate (All-in)']/following-sibling::div/input");
            await bp.Write(page, "//label[text()='03 Months Rate (All-in)']/following-sibling::div/input","300","3monthsrate");

            //for 6 months
            await bp.SimpleClick(page, "//label[text()='06 Months Rate (All-in)']/following-sibling::div/input");
            await bp.Write(page, "//label[text()='06 Months Rate (All-in)']/following-sibling::div/input", "600", "6monthsrate");

            //for 12 months
            await bp.SimpleClick(page, "//label[text()='12 Months Rate (All-in)']/following-sibling::div/input");
            await bp.Write(page, "//label[text()='12 Months Rate (All-in)']/following-sibling::div/input", "1200", "12monthsrate");

            // await page.EvaluateAsync(@"window.scrollBy(0, 1000);");

            //FOr Save Button 
            await bp.Click(page, "//button[text()='Save']", "SaveButton");
        }



        public async Task SearchSygnals(IPage page, string searchOrigin, string searchDest,string searchTT, string searchVol, string searchVF)
        {
            
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Search']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Search']/following-sibling::div/input", searchOrigin, "Search");

            //For Origin
           // extent.ChildLog("Origin");
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Origin']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Origin']/following-sibling::div/input", searchOrigin, "Sygnals:Origin");

            //For OriginDH
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Origin DH']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Origin DH']/following-sibling::div/input", OriginDH, "Sygnal:OriginDH");

            //For Destionation
            //extent.ChildLog("Destination");
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Destination']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Destination']/following-sibling::div/input", searchDest, "SygnalsDestination");

            //For DestinationiDH
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Detination DH']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Detination DH']/following-sibling::div/input", DestinationDH, "SygnalsDestination");

            //For Trailer Type
            //extent.ChildLog("Trailer Type");
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Trailer Type']/following-sibling::div");
            await bp.Click(page, $"//li[text()='{searchTT}']", "SygnalsTrailerType");


            //For Volume
            //extent.ChildLog("Volume");
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Volume']/following-sibling::div/input");
            await bp.Write(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Volume']/following-sibling::div/input", searchVol, "SygnalsVolume");

            //For Frequency
            //extent.ChildLog("Volume Frequency");
            await bp.SimpleClick(page, "//h3[text()='Sygnals']/parent::div/parent::div/div/following-sibling::div/div/div/div/div/div/label[text()='Volume Frequency']/following-sibling::div");
            await bp.Click(page, $"//li[text()='{searchVF}']", "SygnalsFrequency");
        }

        public async Task UpdateSygnal(IPage page)
        {
            //For last inserted record updation
            await bp.Wait(3000);
            
            //For Update pencil
            await bp.SimpleClick(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{origin}')]/following-sibling::div[7]/div/div[1]");

            //For Van click
            await bp.Click(page, "//div[contains(@class,'MuiBox-root css-19nzcwv')]//p[text()='Flatbed']", "Update checkbox");

            //for Update Button
            await bp.Click(page, "//button[text()='Update']", "Update Button");
        }
        public async Task DeleteSygnal(IPage page)
        {
           
            await SearchSygnals(page,origin, dest, "Flatbed", Vol, VF);
            await bp.Wait(3000);
            await bp.SimpleClick(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{origin}')]/following-sibling::div[7]/div/div[3]");
            await bp.Click(page, "//button[text()='Yes']", "DeleteRecord");
        }
    }
}
