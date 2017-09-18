using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class ChangeContactProperties : Common_Test

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
        public void TC3_Verify_user_can_publish_an_unpublished_contact()
        {
            contactNewPage = new ContactNew_Page();
            contactNewPage.CreateNewContact(randomTitle,unPublishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.PublishContact(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(publishContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC4_Verify_user_can_unpublish_a_published_contact()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.UnpublishContact(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC5_Verify_user_can_move_a_contact_to_the_archive()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.ArchiveContact(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(archiveContactSuccessMessage, getMessage);

            contactManagePage.searchContact("", archiveStatus, "", "", "", "", "", "");

            bool isTitleExistOnTable = contactManagePage.IsContactExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestMethod]
        public void TC6_Verify_user_can_check_in_a_contact()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            commonPage.QuitBrowser();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            controlPanelPage.OpenContactPage();

            contactManagePage.CheckInContact(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(checkInContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC7_Verify_user_can_move_a_contact_to_trash_section()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.TrashContact(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(trashContactSuccessMessage, getMessage);

            contactManagePage.searchContact("", "Trashed", "", "", "", "", "", "");

            bool isTitleExistOnTable = contactManagePage.IsContactExistOnTable(randomTitle);

            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC15_Verify_user_can_change_the_status_of_contacts_using_the_Status_column()
        {
            contactNewPage = new ContactNew_Page();
            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.SelectTitle(randomTitle);

            contactManagePage.ChangeStatusByIcon(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishContactSuccessMessage, getMessage);

            contactManagePage.SelectTitle(randomTitle);

            contactManagePage.ChangeStatusByIcon(randomTitle);

            getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(publishContactSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC16_Verify_user_can_change_the_feature_property_of_contacts_using_the_Featured_column()
        {
            contactNewPage = new ContactNew_Page();

            contactNewPage.CreateNewContact(randomTitle, publishStatus, categoryContact, saveAndClose, "", "", "");

            string getMessage = contactManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createContactSuccessMessage, getMessage);

            contactManagePage.SelectTitle(randomTitle);

            contactManagePage.ChangeFeatureByIcon(randomTitle);

            //check icon featured
            bool isContactFeature = contactManagePage.IsContactFeature(randomTitle);
            CheckTitleIsFeatured(isContactFeature);

            contactManagePage.SelectTitle(randomTitle);

            contactManagePage.ChangeFeatureByIcon(randomTitle);

            //check icon unfeatured
            bool isContactUnFeature = contactManagePage.IsContactUnFeature(randomTitle);
            CheckTitleIsUnfeatured(isContactUnFeature);

        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
