using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla.Test_Class
{
    [TestClass]
    public class Test : Common_Test

    {
        Common_Page commonPage= new Common_Page();
        Login_Page loginPage = new Login_Page();
        ArticlesNew_Page articleNewPage = new ArticlesNew_Page();
        ArticlesEdit_Page articleEditPage = new ArticlesEdit_Page();
        ControlPanel_Page controlPanelPage = new ControlPanel_Page();


        string publishStatus = "Published";
        string unPublishStatus = "Unpublished";
        string archiveStatus = "Archived";
        string category = "- Category 2";
        string guestAccess = "Guest";
        string author = "Thanh Tran";
        string contentEdit = " Edit rồi";
        string content = "Trần Chí Thành";
        string saveAndClose = "Save and Close";
        string categoryEdit = "- catagory 1";


        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContent)
        {
            Console.WriteLine("Run ClassInitialize");
        }

        [TestInitialize]
        public void MyTestInitialize()
        {

        }

        //[TestMethod]
        //public void DoNotRun3()
        //{

        //    //commonPage.NavigateJoomla();

        //    //loginPage.Login(username, password);

        //    //controlPanelPage.hovering();

        //}
    }
}