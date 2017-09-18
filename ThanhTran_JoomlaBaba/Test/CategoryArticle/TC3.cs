using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class TC3: Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ClientManage_Page clientManagePage;
        ClientNew_Page clientNewPage;
        ControlPanel_Page controlPanelPage;
        BannerManage_Page bannerManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();
            randomTitle2 = RandomTitle() + " 2";

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenBannerPage();

            bannerManagePage = new BannerManage_Page();
            bannerManagePage.OpenClientPage();

        }

        [TestMethod]
        public void TC3_TEST_Verify_that_user_can_create_many_clients_by_using_Save_and_New_button()
        {
            clientManagePage = new ClientManage_Page();
            clientManagePage.OpenNewClientPage();

            clientNewPage = new ClientNew_Page();
            clientNewPage.CreateNewClient(randomTitle, "", "Save and New", contactName, contactEmail);

            string getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            clientNewPage.CreateNewClient(randomTitle2, "", "Save and Close", contactName, contactEmail);

            getMessage = clientManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createClientSuccessMessage, getMessage);

            bool isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

            isTitleExistOnTable = clientManagePage.IsClientExistOnTable(randomTitle2);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }
    
        [TestCleanup]
        public void MyTestCleanup()
        {
            commonPage.QuitBrowser();
        }

    }
}
