using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class TC1 : Common_Test

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
            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenCategoryArticlePage();
        }

        [TestMethod]
        public void TC1_TEST_Verify_user_can_search_category_using_the_filter_textbox()
        {
            categoryArticleManagePage = new CategoryArticleManage_Page();
            categoryArticleManagePage.OpenNewCategoryArticlePage();

            categoryArticleNewPage = new CategoryArticleNew_Page();
            categoryArticleNewPage.CreateNewCategoryArticle(randomTitle, "", saveAndClose, "");

            string getMessage = categoryArticleManagePage.getControlMessage(categoryArticleManagePage.alertNotify);
            CheckMessage(createArticleCategorySuccessMessage, getMessage);

            categoryArticleManagePage.searchCategoryArticle(randomTitle, "", "", "");

            bool isTitleExistOnTable = categoryArticleManagePage.IsCategoryArticleExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }    

        [TestCleanup]
        public void MyTestCleanup()
        {
            commonPage.QuitBrowser();
        }

    }
}
