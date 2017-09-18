using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class ChangeBannerProperties : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        BannerManage_Page bannerManagePage;
        BannerNew_Page bannerNewPage;
        ControlPanel_Page controlPanelPage;
        ClientManage_Page clientManagePage;
        ClientNew_Page clientNewPage;
        CategoryNew_Page categoryNewPage;
        CategoryManage_Page categoryManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
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
        public void TC4_Verify_that_user_can_unpublish_a_banner()
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
            bannerNewPage.CreateNewBanner(bannerTitle, "", saveAndClose, categoryTitle, clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);

            bannerManagePage.UnpublishBanner(bannerTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishBannerSuccessMessage, getMessage);

            //CreateEditBanner createdit = new CreateEditBanner();
            //createdit.TC1_Verify_that_user_can_create_new_banner();
        }

        [TestMethod]
        public void TC5_Verify_that_user_can_archive_a_banner()
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
            bannerNewPage.CreateNewBanner(bannerTitle, "", saveAndClose, categoryTitle, clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);

            bannerManagePage.ArchiveBanner(bannerTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(archiveBannerSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC6_Verify_that_user_can_trash_a_banner()
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
            bannerNewPage.CreateNewBanner(bannerTitle, "", saveAndClose, categoryTitle, clientTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);

            bannerManagePage.TrashBanner(bannerTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(trashBannerSuccessMessage, getMessage);

            bannerManagePage.searchBanner("", "Trashed", "","");

            bool isTitleExistOnTable = bannerManagePage.IsBannerExistOnTable(bannerTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestMethod]
        public void TC10_Verify_that_user_can_check_in_a_banner()
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
            bannerNewPage.CreateNewBanner(bannerTitle, "", "Save", categoryTitle, clientTitle);

            getMessage = bannerNewPage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createBannerSuccessMessage, getMessage);

            //commonPage.driver.Quit();
            bannerNewPage.QuitBrowser();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            controlPanelPage.OpenBannerPage();

            bannerManagePage.CheckInBanner(bannerTitle);

            getMessage = bannerManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(checkInBannerSuccessMessage, getMessage);


        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
