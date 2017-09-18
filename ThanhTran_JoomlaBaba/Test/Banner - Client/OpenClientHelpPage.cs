using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class OpenClientHelpPage : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ClientManage_Page clientManagePage;
        ControlPanel_Page controlPanelPage;
        ClientNew_Page clientNewPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            clientManagePage = new ClientManage_Page();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();

            clientManagePage.OpenClientPage();
        }

        [TestMethod]
        public void TC7_Verify_that_user_can_browse_Banner_client_help_page()
        {
            clientManagePage.OpenHelpPage();
            CheckWindowDisplaying("Joomla! Help Screens");
        }

        [TestMethod]
        public void TC12_Verify_that_user_can_browse_New_client_help_page()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.OpenHelpPage();
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
