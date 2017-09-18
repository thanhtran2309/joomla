using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Pages.Banners;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class CreateEditBanner: Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        BannerManage_Page bannerManagePage;
        BannerNew_Page bannerNewPage;
        BannerEdit_Page bannerEditPage;
        ControlPanel_Page controlPanelPage;
        ClientManage_Page clientManagePage;
        ClientNew_Page clientNewPage;
        CategoryNew_Page categoryNewPage;
        CategoryManage_Page categoryManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();
            bannerTitle = RandomTitle() + " banner";
            categoryTitle = RandomTitle() + " category";
            clientTitle = RandomTitle() + " client";


            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();
        }

        [TestMethod]
        public void TC1_Verify_that_user_can_create_new_banner()
        {
            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

            clientManagePage = new ClientManage_Page();
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(clientTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.OpenCategoryPage();

            categoryManagePage = new CategoryManage_Page();
            categoryManagePage.OpenNewCategoryPage();

            categoryNewPage = new CategoryNew_Page();
            categoryNewPage.CreateNewCategory(categoryTitle, "",saveAndClose,"");

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createCategorySuccessMessage, getMessage);

            clientManagePage.OpenBannerPage();

            bannerManagePage.OpenNewBannerPage();

            bannerNewPage = new BannerNew_Page();
            bannerNewPage.CreateNewBanner(bannerTitle,"",saveAndClose,categoryTitle,clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC2_Verify_that_user_can_edit_a_banner()
        {
            TC1_Verify_that_user_can_create_new_banner();
            bannerManagePage.OpenEditPage(bannerTitle);

            bannerEditPage = new BannerEdit_Page();
            bannerEditPage.EditBanner(bannerTitle+ " edit","",saveAndClose,"","");

            string getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC3_Verify_that_user_can_create_a_new_banner_with_unpublished_status()
        {
            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

            clientManagePage = new ClientManage_Page();
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(clientTitle, "", saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.OpenCategoryPage();

            categoryManagePage = new CategoryManage_Page();
            categoryManagePage.OpenNewCategoryPage();

            categoryNewPage = new CategoryNew_Page();
            categoryNewPage.CreateNewCategory(categoryTitle, "", saveAndClose, "");

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createCategorySuccessMessage, getMessage);

            clientManagePage.OpenBannerPage();

            bannerManagePage.OpenNewBannerPage();

            bannerNewPage = new BannerNew_Page();
            bannerNewPage.CreateNewBanner(bannerTitle, unPublishStatus, saveAndClose, categoryTitle, clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC11_Verify_that_user_can_create_many_banners_by_using_Save_and_New_button()
        {
            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

            clientManagePage = new ClientManage_Page();
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(clientTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.OpenCategoryPage();

            categoryManagePage = new CategoryManage_Page();
            categoryManagePage.OpenNewCategoryPage();

            categoryNewPage = new CategoryNew_Page();
            categoryNewPage.CreateNewCategory(categoryTitle, "", saveAndClose, "");

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createCategorySuccessMessage, getMessage);

            clientManagePage.OpenBannerPage();

            bannerManagePage.OpenNewBannerPage();

            bannerNewPage = new BannerNew_Page();
            bannerNewPage.CreateNewBanner(bannerTitle, "", "Save and New", categoryTitle, clientTitle);

            bannerEditPage = new BannerEdit_Page();
            getMessage = bannerEditPage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);

            bannerEditPage.EditBanner(bannerTitle+" new", "",saveAndClose, categoryTitle, clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC14_Verify_that_user_cannot_create_a_new_banner_without_entering_the_name_of_the_banner()
        {
            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

            clientManagePage = new ClientManage_Page();
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(clientTitle, publishStatus, saveAndClose, contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientManagePage.OpenCategoryPage();

            categoryManagePage = new CategoryManage_Page();
            categoryManagePage.OpenNewCategoryPage();

            categoryNewPage = new CategoryNew_Page();
            categoryNewPage.CreateNewCategory(categoryTitle, "", saveAndClose, "");

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createCategorySuccessMessage, getMessage);

            clientManagePage.OpenBannerPage();

            bannerManagePage.OpenNewBannerPage();

            bannerNewPage = new BannerNew_Page();
            bannerNewPage.CreateNewBanner("", "", saveAndClose, categoryTitle, clientTitle);

            bool isControlChangeToRed = bannerNewPage.IsControlChangeToRed(bannerNewPage.titleTextField);
            CheckIsControlChangeToRed(isControlChangeToRed);

        }

        //[TestMethod]
        //public void TC11_Verify_that_user_can_create_many_clients_by_using_Save_and_New_button()
        //{
        //    bannerManagePage.OpenNewClientPage();

        //    bannerNewPage = new ClientNew_Page();
        //    bannerNewPage.CreateNewClient(randomTitle, publishStatus, "Save and New", contactName, contactEmail);

        //    string getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
        //    CheckMessage(createClientSuccessMessage, getMessage);

        //    bannerNewPage.CreateNewClient(randomTitle + "2", publishStatus, "Save and Close", contactName, contactEmail);

        //    getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
        //    CheckMessage(createClientSuccessMessage, getMessage);
        //}

        //[TestMethod]
        //public void TC14_User_cannot_create_a_new_client_without_entering_the_name_of_the_client()
        //{
        //    bannerManagePage.OpenNewClientPage();

        //    bannerNewPage = new ClientNew_Page();
        //    bannerNewPage.CreateNewClient("", publishStatus, saveAndClose, contactName, contactEmail);

        //    bool isControlChangeToRed = bannerNewPage.IsControlChangeToRed(bannerNewPage.titleTextField);
        //    CheckIsControlChangeToRed(isControlChangeToRed);
        //}

        //[TestMethod]
        //public void TC15_User_cannot_create_a_new_client_after_entering_invalid_email_address()
        //{
        //    bannerManagePage.OpenNewClientPage();

        //    bannerNewPage = new ClientNew_Page();
        //    bannerNewPage.CreateNewClient(randomTitle, publishStatus, saveAndClose, contactName, "invalid email");

        //    bool isControlChangeToRed = bannerNewPage.IsControlChangeToRed(bannerNewPage.emailTextField);
        //    CheckIsControlChangeToRed(isControlChangeToRed);
        //}


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
