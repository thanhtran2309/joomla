using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class SortClient : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ControlPanel_Page controlPanelPage;
        ClientManage_Page clientManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            clientManagePage = new ClientManage_Page();

            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();

            clientManagePage.OpenClientPage();
        }


        //[TestMethod]
        //public void TC11_Verify_user_can_sort_the_banner_table_by_ID_columns()
        //{
        //    clientManagePage.ClickIDbutton();

        //    bool isIdAscending = clientManagePage.IsIdAscending();
        //    CheckIsIdAscending(isIdAscending);

        //    clientManagePage.ClickIDbutton();

        //    bool isIdDescending = clientManagePage.IsIdDescending();
        //    CheckIsIdDescending(isIdDescending);
        //}

        [TestMethod]
        public void TC16_Verify_that_user_can_change_the_quantity_of_items_displayed_in_client_table()
        {
            clientManagePage.SelectDisplayRow("5");

            bool doesNumberRowDisplayCorrectly = clientManagePage.IsRowDisplayEqualtoInput();
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
