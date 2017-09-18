using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class TC2 : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        CategoryArticleManage_Page categoryArticleManagePage;
        ControlPanel_Page controlPanelPage;
        CategoryArticleNew_Page categoryArticleNewPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenCategoryArticlePage();
        }

        [TestMethod]
        public void TC2_TEST_Verify_that_user_can_browse_New_Category_help_page()
        {
            categoryArticleManagePage = new CategoryArticleManage_Page();
            categoryArticleManagePage.OpenNewCategoryArticlePage();

            categoryArticleNewPage = new CategoryArticleNew_Page();
            categoryArticleNewPage.OpenCategoryArticleNewHelpPage();

            bool isTitleWindowExist = commonPage.IsTitleWindowExist("Help36:Components Content Categories");
            CheckIsWindownHasTheTitleExist(isTitleWindowExist);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            commonPage.QuitBrowser();
        }

    }
}
