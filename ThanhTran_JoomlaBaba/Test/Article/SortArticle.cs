using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class SortArticle : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ControlPanel_Page controlPanelPage;
        ArticleManage_Page articleManagePage;

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
        public void TC11_Verify_user_can_sort_the_article_table_by_ID_column()
        {
            articleManagePage.ClickIDbutton();

            bool isIdAscending = articleManagePage.IsIdAscending();
            CheckIsIdAscending(isIdAscending);

            articleManagePage.ClickIDbutton();

            bool isIdDescending = articleManagePage.IsIdDescending();
            CheckIsIdDescending(isIdDescending);
        }

        [TestMethod]
        public void TC12_Verify_user_can_paging_the_articles_using_the_paging_control()
        {
            articleManagePage.SelectDisplayRow("5");

            bool doesNumberRowDisplayCorrectly = articleManagePage.IsRowDisplayEqualtoInput();
            CheckNumberRowDisplay(doesNumberRowDisplayCorrectly);
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
