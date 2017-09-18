using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class SearchClient: Common_Test

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

            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();

            clientManagePage.OpenClientPage();
        }

        [TestMethod]
        public void TC8_Verify_that_user_can_search_a_client__by_using_filter_textbox()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.searchClient(randomTitle, "", "");

            bool isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestMethod]
        public void TC9_Verify_that_user_can_search_a_client_by_using_filter_dropdown_list()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);

            CheckMessage(createClientSuccessMessage, getMessage);
            clientManagePage.searchClient("", publishStatus, "");

            bool isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
