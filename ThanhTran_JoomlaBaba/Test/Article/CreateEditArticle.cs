using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla
{
    [TestClass]
    public class CreateEditArticle: Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ArticleManage_Page articleManagePage;
        ArticlesNew_Page articleNewPage;
        ArticlesEdit_Page articleEditPage;
        ControlPanel_Page controlPanelPage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            randomTitle = RandomTitle();

            articleManagePage = new ArticleManage_Page();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenArticlePage();
        }

        [TestMethod]
        public void TC1_Verify_user_can_create_new_article_with_valid_information()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC2_Verify_user_can_edit_an_article()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.OpenEditPage(randomTitle);

            articleEditPage = new ArticlesEdit_Page();
            articleEditPage.EditArticle(randomTitle + " edit", publishStatus, categoryArticle, contentEdit, saveAndClose, "", "", "");

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC13_Verify_user_can_add_image_to_articles_content()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "powered_by.png");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
