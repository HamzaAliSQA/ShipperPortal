using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShipperPortal
{
    public class Loginpage 
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public async Task Login(IPage page)
        {
            extent.ParentLog("Carrier Portal Login");
            extent.ChildLog("Login Page");
            await bp.Goto(page, "https://staging-carrier.trusygnal.com/login/");
            await bp.Wait(5000);
            await bp.Write(page, "#\\:r0\\:", "dsv", "username");
            await bp.Write(page, "#auth-login-v2-password", "DSV!@123", "password");
            await bp.Click(page, "button:has-text('Login')", "Login");

           // try
           // {
                //var welcomeMessage = await page.WaitForSelectorAsync("//h4[text()='Shipper Portal']");
                // if (welcomeMessage != null)
                //{
                //var actualOutCome = await welcomeMessage.InnerTextAsync();
             //   extent.ChildLog("Shipper Portal Dashboard");
             //   await bp.Assertion(page, "//h4[text()='Shipper Portal']", "Shipper Portal", "Shipper portal");
                //}
               /// else
               // {
                    //Console.WriteLine("Welcome Message not found!");
               /// }
           // }
           // catch(Exception ex) 
           // {
           ///     Console.WriteLine("An error occurred while processing the welcome message: " + ex.Message);
           // }

            //await bp.Wait(4000);
        }
    }
}
