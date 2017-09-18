using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using ThanhTran_Joomla.Pages.Banners;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class SearchBanner : Common_Test

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

            bannerManagePage = new BannerManage_Page();

            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();
        }

        [TestMethod]
        public void TC8_Verify_that_user_can_search_a_banner_by_using_filter_textbox()
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

            bannerManagePage.searchBanner(bannerTitle, "", "","");

            bool isTitleExistOnTable = bannerManagePage.IsBannerExistOnTable(bannerTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestMethod]
        public void TC9_Verify_that_user_can_search_a_banner_by_using_filter_dropdown_lists()
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

            bannerManagePage.searchBanner("", "", categoryTitle,clientTitle);

            bool isTitleExistOnTable = bannerManagePage.IsBannerExistOnTable(bannerTitle);
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
