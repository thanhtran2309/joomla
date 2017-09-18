using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class ChangeClientProperties : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ClientNew_Page clientNewPage;
        ControlPanel_Page controlPanelPage;
        ClientManage_Page clientManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();

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
        public void TC3_Verify_that_user_can_publish_a_client()

        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, unPublishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.PublishClient(randomTitle);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(publishClientSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC4_Verify_that_user_can_unpublish_a_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);

            CheckMessage(createClientSuccessMessage, getMessage);
            clientManagePage.UnpublishClient(randomTitle);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishClientSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC5_Verify_that_user_can_archive_a_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.ArchiveClient(randomTitle);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(archiveClientSuccessMessage, getMessage);

            clientManagePage.searchClient("", archiveStatus, "");

            bool isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC6_Verify_that_user_can_send_a_client_to_trash()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.TrashClient(randomTitle);

            commonPage.WaitForPageLoading(10000);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(trashClientSuccessMessage, getMessage);

            clientManagePage.searchClient("", "Trashed", "");

            bool isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC10_Verify_that_user_can_check_in_a_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, "Save", contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            //commonPage.driver.Quit();
            commonPage.QuitBrowser();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            controlPanelPage.OpenBannerPage();

            clientManagePage.OpenClientPage();

            clientManagePage.CheckInClient(randomTitle);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(checkInClientSuccessMessage, getMessage);
        }
      

        //[TestMethod]
        //public void TC15_Verify_user_can_change_the_status_of_banners_using_the_Status_column()
        //{
        //    clientManagePage.OpenNewClientPage();

        //    clientNewPage = new ClientNew_Page();
        //    clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose,contactName,contactEmail);

        //    string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
        //    CheckMessage(createBannerSuccessMessage, getMessage);

        //    clientManagePage.SelectTitle(randomTitle);

        //    clientManagePage.ChangeStatusByIcon(randomTitle);

        //    getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
        //    CheckMessage(unPublishBannerSuccessMessage, getMessage);

        //    clientManagePage.SelectTitle(randomTitle);

        //    clientManagePage.ChangeStatusByIcon(randomTitle);

        //    getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
        //    CheckMessage(publishBannerSuccessMessage, getMessage);
        //}


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
