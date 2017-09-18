using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class CreateEditContacts : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ContactManage_Page contactManagePage;
        ContactNew_Page contactNewPage;
        ContactEdit_Page contactEditPage;
        ControlPanel_Page controlPanelPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenContactPage();

            contactManagePage = new ContactManage_Page();
            contactManagePage.OpenNewContactPage();
        }

        [TestMethod]
        public void TC1_Verify_user_can_create_new_contact_with_valid_information()
        {

            contactNewPage = new ContactNew_Page();        
            contactNewPage.CreateNewContact(randomTitle, "",categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC2_Verify_user_can_edit_a_contact()
        {
            contactNewPage = new ContactNew_Page();
            contactNewPage.CreateNewContact(randomTitle, "", categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.OpenEditPage(randomTitle);

            contactEditPage = new ContactEdit_Page();
            contactEditPage.EditContact(randomTitle + " edit", publishStatus, categoryContact, saveAndClose, "", "", "");

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC13_Verify_user_can_add_image_to_contacts_information()
        {
            contactNewPage = new ContactNew_Page();
            contactNewPage.CreateNewContact(randomTitle, "", categoryContact, saveAndClose, "", "", "powered_by.png");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
