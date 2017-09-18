using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class OpenContactHelpPage : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ContactManage_Page contactManagePage;
        ControlPanel_Page controlPanelPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenContactPage();
        }

        [TestMethod]
        public void TC8_Verify_user_can_access_contact_help_section()
        {
            contactManagePage = new ContactManage_Page();
            contactManagePage.OpenHelpPage();
            CheckWindowDisplaying("Joomla! Help Screens");
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
