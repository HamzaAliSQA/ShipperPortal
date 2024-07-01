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
        Dashboard dash = new Dashboard();
        MatchedSygnals ms = new MatchedSygnals();
        RolesManagement RM = new RolesManagement(); 
        Services service   = new Services();
        Logspage log = new Logspage();
        Sygnal syg = new Sygnal();
        User user = new User();
        Down_UploadFile DU_File = new Down_UploadFile();
        CompanyProfile Cp = new CompanyProfile();
        Location loc = new Location();
        Trailer trailer = new Trailer();
        Insurance ins = new Insurance();
        ExtentReport extent = new ExtentReport();
        
        [SetUp]
        public async Task Setup()
        {
            extent.LogReport("Carrier Portal");
            extent.ParentLog(NUnit.Framework.TestContext.CurrentContext.Test.Name);

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
             //Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });
            await Context.CloseAsync();
            await Browser.CloseAsync();

            extent.flush();
            //testung the github
        }
        
        [Test]
        [AllureStep]
        public async Task ShipperCarrier_Login()
        {
            await login.Login(Page);
        }
        [Test]
        [AllureStep]
        public async Task CarrierPortal()
        {
            await login.Login(Page);
            await Task.Delay(3000);
            await dash.DashboardFeature(Page);
            await Task.Delay(3000);
            await ms.Matched_sygnals(Page);
            await Task.Delay(3000);
            await syg.sygnal(Page);
            await Task.Delay(3000);
            await RM.rolesManagement(Page);
            await Task.Delay(3000);
            await log.Logs(Page);
            await Task.Delay(3000);
            await Cp.C_Profile(Page);
            await Task.Delay(2000);
            await service.service(Page);
            await Task.Delay(2000);
            await ins.CP_Insurance(Page);
            await Task.Delay(2000);
            await loc.CP_Location(Page);
            //await trailer.CP_Trailer(Page);
            //await Task.Delay(3000);
            //await user.users(Page);
        }
        
        [Test]
        [AllureStep]
        public async Task Sygnals()
        {
            await login.Login(Page);
            await log.Logs(Page);

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