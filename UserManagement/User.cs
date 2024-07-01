using Microsoft.Playwright;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class User
    {
        Basepage bp = new Basepage();
        ExtentReport extent = new ExtentReport();
        public string name = "Hamza Ali";
        public async Task users(IPage page)
        {

            //Click on the Carrier managment
            extent.ParentLog("UserManagement");
            extent.ChildLog("UserManagement:Users");
            //await bp.Click(page, "//div[@class='scrollbar-container ps']//p[text() ='User Management']", "UserManagment");
            await bp.Wait(10000);
            await bp.Click(page, "//div[@class='scrollbar-container ps']//p[text() ='User Management']/parent::div/parent::div", "UserManagment");
            await Task.Delay(3000);

            await bp.Click(page, "a[href='/users/']", "Users");
            await Task.Delay(1000);
            await Add_New_User(page);
            await Task.Delay(2000);
            await Search_User(page);
            await Task.Delay(2000);
            await delete_User(page);    

        }
        public async Task Add_New_User(IPage page)
        {
            extent.ChildLog("Users:Add New");
            //Add new button
            await bp.Click(page, "//button[text() ='Add New']", "User_AddNew");

            //First Name
            await bp.Write(page, "//label[text()='First Name']/parent::div/div//input", name, "User_AddNew_FirstName");

            //Last Name
            await bp.Write(page, "//label[text()='Last Name']/parent::div/div//input", "Ali", "User_AddNew_LastName");

            //Email
            await bp.Write(page, "//label[text()='Email']/parent::div/div//input", "gyn@gmail.com", "User_AddNew_Email");

            //UserName
            await bp.Write(page, "//label[text()='Username']/parent::div/div//input", "gynhh", "User_AddNew_UserName");

            //Phone
            await bp.Write(page, "//label[text()='Phone']/parent::div/div//input", "0352728990", "User_AddNew_Contact");

            //Admin Role 
            await bp.Click(page, "//label[text()='Role']/parent::div/div//following-sibling::div/button/parent::div/parent::div/input", "User_AdminDropdown");
            await page.FillAsync("//label[text()='Role']/parent::div/div//following-sibling::div/button/parent::div/parent::div/input","a");
            await bp.Keyboardaction(page,"down");
            await bp.Keyboardaction(page,"enter");

            //Password
            await bp.Write(page, "//label[text()='Password']/parent::div/div//input", "", "User_AddNew_Password");

            //Confirm Password
            await bp.Write(page, "//label[text()='Confirm Password']/parent::div/div//input", "123456789", "User_AddNew_ConfirmPassword");

            //Save 
            await bp.Click(page, "//button[text() ='Save']", "User_AddNew_Save");
        }
        public async Task Search_User(IPage page)
        {
            extent.ChildLog("Users:Search");
            //input for search
            await bp.Write(page, "//h1[text() ='Users']/parent::div/parent::div/parent::div//following-sibling::div//input[@placeholder ='Search']", name, "UserSearch");
            await Task.Delay(2000);
        }

        public async Task Edit_User(IPage page)
        {
            extent.ChildLog("Users:Edit");
            //Edit button
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{name}')]/following-sibling::div[3]/div/div[1]", "EditUser");

           // //First Name
           // await bp.Write(page, "//label[text()='First Name']/parent::div/div//input", "gyn", "UserEdit_FirstName");
           //
           // //Last Name
           // await bp.Write(page, "//label[text()='Last Name']/parent::div/div//input", "hh", "UserEdit_LastName");
           //
           // //Email
           // await bp.Write(page, "//label[text()='Email']/parent::div/div//input", "gyn@gmail.com", "UserEdit_Email");
           //
           // //UserName
           // await bp.Write(page, "//label[text()='Username']/parent::div/div//input", "gynhh", "UserEdit_Username");
           
            //Phone
            await bp.Write(page, "//label[text()='Phone']/parent::div/div//input", "0312343443", "UserEdit_Password");

            
            //Save 
            await bp.Click(page, "//button[text() ='Save']", "UserEdit_Save");
        }


        public async Task delete_User(IPage page)
        {
            extent.ChildLog("Users:Delete");
            //Click on delete button
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]/div/following-sibling::div[contains(text(),'{name}')]/following-sibling::div[3]/div/div[3]", "User_Delete");

            //Modal For confirmation 
            await bp.Click(page, "//button[text()='Yes']", "deletionConfirmation");

        }
    }
}
