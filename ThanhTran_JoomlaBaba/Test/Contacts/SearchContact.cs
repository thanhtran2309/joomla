using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class SearchContact : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ContactManage_Page contactManagePage;
        ContactNew_Page contactNewPage;
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
        public void TC9_Verify_user_can_search_for_contact_using_the_filter_text_field()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.searchContact(randomTitle, "", "", "", "", "", "", "");

            bool isTitleExistOnTable = contactManagePage.IsContactExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC10_Verify_user_can_search_for_contact_using_the_filter_dropdown_lists()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.searchContact("", publishStatus, categoryContact, guestAccess, author, "", "", "");

            bool isTitleExistOnTable = contactManagePage.IsContactExistOnTable(randomTitle);
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
