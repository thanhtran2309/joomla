using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class SearchArticle : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ArticleManage_Page articleManagePage;
        ControlPanel_Page controlPanelPage;
        ArticlesNew_Page articleNewPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            articleManagePage = new ArticleManage_Page();

            randomTitle = RandomTitle();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenArticlePage();
        }

        [TestMethod]
        public void TC9_Verify_user_can_search_for_articles_using_the_filter_text_field()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.searchArticle(randomTitle, "", "", "", "", "", "", "");

            bool isTitleExistOnTable = articleManagePage.IsArticleExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);
        }

        [TestMethod]
        public void TC10_Verify_user_can_search_for_articles_using_the_filter_dropdown_lists()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);

            CheckMessage(createArticleSuccessMessage, getMessage);
            articleManagePage.searchArticle("", publishStatus, categoryArticle, guestAccess, author, "", "", "");

            bool isTitleExistOnTable = articleManagePage.IsArticleExistOnTable(randomTitle);
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
