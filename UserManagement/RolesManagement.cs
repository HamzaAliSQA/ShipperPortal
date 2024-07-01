using Microsoft.Playwright;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipperPortal
{
    public class RolesManagement
    {
        Basepage bp = new Basepage();   
        ExtentReport extent = new ExtentReport();
        public string Rolename = "SQAAli";
        public string UpdateRolename = "AliSQA";

        public async Task rolesManagement(IPage page)
        {
            extent.ParentLog("Roles & Permission");
            extent.ChildLog("UserManagement:Roles & Permission");
            await bp.Click(page, "//div[@class='scrollbar-container ps']//p[text() ='User Management']/parent::div/parent::div", "UserManagment");
            await Task.Delay(3000);
            await bp.Click(page, "a[href='/users/roles/']", "Roles & Permission");
            await Task.Delay(2000);
            await Add_New_User(page);
            await Task.Delay(2000);
            await Edit_Role(page);
            await Task.Delay(2000);
            await permission(page);
        }
        public async Task Add_New_User(IPage page)
        {
            extent.ChildLog("Roles & Permission:Add New");
            
            //Add new button
            await bp.Click(page, "//button[text() ='+ Add New']", "Role_AddNew");

            //Name
            await bp.Write(page, "//label[text()='Name']/parent::div/div/input", Rolename, "Role_Name");

            //Save 
            await bp.Click(page, "//button[text() ='Save']", "Role_Save");
        }
        public async Task Edit_Role(IPage page)
        {
            extent.ChildLog("Roles & Permission:Edit");
            //Edit button
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]//p[contains(text(),'{Rolename}')]/parent::div/following-sibling::div[2]/div/div[2]", "RoleEdit_Save");

            //Name
            await bp.Write(page, "//label[text()='Name']/parent::div/div//input", UpdateRolename, "RoleEdit_Name");

            //Save 
            await bp.Click(page, "//button[text() ='Save']", "RoleEdit_Save");
        }
        public async Task permission(IPage page)
        {
            extent.ChildLog("Roles & Permission:Privacy");
            //Privacy
            await bp.Click(page, $"//div[contains(@class,'MuiDataGrid-row')]//p[contains(text(),'{UpdateRolename}')]/parent::div/following-sibling::div[2]/div/div[1]", "UserManagement_Permission");

            //User Management
            await bp.Click(page, "//b[text()  ='USER MANAGEMENT']/parent::p/parent::div/following-sibling::div//div/p[text()='READ'][1]", "UserManagement_Permission_Read");

            //Role Management
            await bp.Click(page, "//b[text()  ='ROLE MANAGEMENT']/parent::p/parent::div/following-sibling::div//div/p[text()='UPDATE'][1]", "RoleManagement_Permission_Update");

            //Program
            await bp.Click(page, "//b[text()  ='PROGRAM']/parent::p/parent::div/following-sibling::div//div/p[text()='CREATE'][1]", "Program_Permission_Create");

            //Insurance Coverage
            await bp.Click(page, "//b[text()  ='INSURANCE COVERAGE']/parent::p/parent::div/following-sibling::div//div/p[text()='UPDATE'][1]", "InsurancePermission_update");

            //trailer
            await bp.Click(page, "//b[text()  ='TRAILER']/parent::p/parent::div/following-sibling::div//div/p[text()='DELETE'][1]", "Trailer_Permission_Delete");

            //services
            await bp.Click(page, "//b[text()  ='SERVICES']/parent::p/parent::div/following-sibling::div//div/p[text()='UPDATE'][1]", "Services_Permission_UPdate");

            //Registration
            await bp.Click(page, "//b[text()  ='REGISTRATIONS']/parent::p/parent::div/following-sibling::div//div/p[text()='UPDATE'][1]", "Registration_Permission_Update");

            //logs module
            await bp.Click(page, "//b[text()  ='LOGS MODULE']/parent::p/parent::div/following-sibling::div//div/p[text()='DELETE'][1]", "Logs_Permission_Read");

            //Update
            await bp.Click(page, "//button[text() ='Update']", "Permission_Update");

            //Close
            await bp.Click(page, "//button[text() ='Close']", "Permission_Close");

        }
    }
}
