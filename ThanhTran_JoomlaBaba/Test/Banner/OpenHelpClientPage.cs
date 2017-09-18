using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class OpenHelpAndClientPage : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        BannerManage_Page bannerManagePage;
        ControlPanel_Page controlPanelPage;
        BannerNew_Page bannerNewPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();

            bannerManagePage = new BannerManage_Page();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();
        }

        [TestMethod]
        public void TC7_Verify_that_user_can_browse_Banner_help_page()
        {
            bannerManagePage.OpenHelpPage();
            CheckWindowDisplaying("Joomla! Help Screens");
        }

        [TestMethod]
        public void TC12_Verify_that_user_can_browse_New_Banner_help_page_in_New_banner_page()
        {
            bannerManagePage.OpenNewBannerPage();
            bannerNewPage = new BannerNew_Page();
            bannerNewPage.OpenHelpPage();
            CheckWindowDisplaying("Joomla! Help Screens");
        }

        [TestMethod]
        public void TC17_Verify_that_user_can_access_Banner_clients_page_while_browsing_Banner_page()
        {
            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

            bool isCurrentWinDownDisplaying = commonPage.IsCurrentWindowPageDisplaying("Banners: Clients");
            CheckIsCurrentWinDownDisplaying(isCurrentWinDownDisplaying);

        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
