using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class SortBanner : Common_Test

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
            bannerManagePage = new BannerManage_Page();

            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();

            bannerManagePage.OpenClientPage();
        }


        [TestMethod]
        public void TC16_Verify_that_user_can_sort_items_displayed_in_banner_table_by_ID()
        {
            bannerManagePage.ClickIDbutton();

            bool isIdAscending = bannerManagePage.IsIdAscending();
            CheckIsIdAscending(isIdAscending);

            bannerManagePage.ClickIDbutton();

            bool isIdDescending = bannerManagePage.IsIdDescending();
            CheckIsIdDescending(isIdDescending);
        }

        [TestMethod]
        public void TC15_Verify_that_user_can_change_the_quantity_of_items_displayed_in_banner_table()
        {
            bannerManagePage.SelectDisplayRow("5");

            bool doesNumberRowDisplayCorrectly = bannerManagePage.IsRowDisplayEqualtoInput();
            CheckNumberRowDisplay(doesNumberRowDisplayCorrectly);
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
