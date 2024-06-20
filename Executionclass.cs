using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace ShipperPortal
{
    [AllureNUnit]
    [TestFixture]
    public class Executionclass : PageTest
    {
        Loginpage login = new Loginpage();
        MatchedSygnals ms = new MatchedSygnals();
        Sygnals syg = new Sygnals();
        AddSygnal addsyg = new AddSygnal();
        Down_UploadFile DU_File = new Down_UploadFile();
        CompanyProfile Cp = new CompanyProfile();
        Location loc = new Location();
        Trailer trailer = new Trailer();
        Insurance ins = new Insurance();
        ExtentReport extent = new ExtentReport();
        
        [SetUp]
        public async Task Setup()
        {
            extent.LogReport("Shipper Carrier");
            //extent.ParentLog(NUnit.Framework.TestContext.CurrentContext.Test.Name);

            ContextOptions();

            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }
        [TearDown]
        public async Task Teardown()
        {
            Thread.Sleep(3000);
            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });
            await Context.CloseAsync();
            await Browser.CloseAsync();

            extent.flush();
        }
        
        [Test]
        [AllureStep]
        public async Task ShipperCarrier_Login()
        {
            await login.Login(Page);
        }
        [Test]
        [AllureStep]
        public async Task Matched_Sygnals()
        {
            await login.Login(Page);
            await DU_File.DownUploadFile(Page);
            //await addsyg.AddnewSygnal(Page);
            //await trailer.CP_Trailer(Page);
            //await ins.CP_Insurance(Page);
            //await loc.CP_Location(Page);
            //await Cp.C_Profile(Page);
            
            //await ms.Matched_sygnals(Page);
            //await Task.Delay(3000);
            //await syg.sygnals(Page);
        }
        /*
        [Test]
        [AllureStep]
        public async Task Sygnals()
        {
            await login.Login(Page);
            await syg.sygnals(Page);
        }
        /*[Test]
        [AllureStep]
        public async Task DUFile()
        {
            await login.Login(Page);
            await DU_File.DownUploadFile(Page);
        }*/

        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = @"videos/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString(),
                //StorageStatePath = @"state\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 780,
                    Width = 1380
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 780,
                    Width = 1380
                }
            };

        }
    }
}