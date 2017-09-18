using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Pages.Banners;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class CreateEditClient: Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ClientManage_Page clientManagePage;
        ClientNew_Page clientNewPage;
        ClientEdit_Page clientEditPage;
        ControlPanel_Page controlPanelPage;

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
        public void TC1_Verify_that_user_can_create_a_new_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose,contactName,contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC2_Verify_that_user_can_edit_a_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.OpenEditPage(randomTitle);

            clientEditPage = new ClientEdit_Page();
            clientEditPage.EditClient(randomTitle + " edit", publishStatus, saveAndClose,contactName,contactEmail);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC11_Verify_that_user_can_create_many_clients_by_using_Save_and_New_button()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, "Save and New", contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientNewPage.CreateNewClient(randomTitle + "2", publishStatus, "Save and Close", contactName, contactEmail);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC14_User_cannot_create_a_new_client_without_entering_the_name_of_the_client()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient("", publishStatus, saveAndClose, contactName, contactEmail);

            bool isControlChangeToRed = clientNewPage.IsControlChangeToRed(clientNewPage.titleTextField);
            CheckIsControlChangeToRed(isControlChangeToRed);
        }

        [TestMethod]
        public void TC15_User_cannot_create_a_new_client_after_entering_invalid_email_address()
        {
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, "invalid email");

            bool isControlChangeToRed = clientNewPage.IsControlChangeToRed(clientNewPage.emailTextField);
            CheckIsControlChangeToRed(isControlChangeToRed);
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
