using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class ChangeArticleProperties : Common_Test

    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ArticlesNew_Page articleNewPage;
        ControlPanel_Page controlPanelPage;
        ArticleManage_Page articleManagePage;

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
        public void TC3_Verify_user_can_publish_an_unpublished_article()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, unPublishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.PublishArticle(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(publishArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC4_Verify_user_can_unpublish_a_published_article()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);

            CheckMessage(createArticleSuccessMessage, getMessage);
            articleManagePage.UnpublishArticle(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC5_Verify_user_can_move_an_article_to_the_archive()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.ArchiveArticle(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(archiveArticleSuccessMessage, getMessage);

            articleManagePage.searchArticle("", archiveStatus, "", "", "", "", "", "");

            bool isTitleExistOnTable = articleManagePage.IsArticleExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC6_Verify_user_can_check_in_an_article()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, "Save", "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            //commonPage.driver.Quit();
            commonPage.QuitBrowser();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            controlPanelPage.OpenArticlePage();

            articleManagePage.CheckInArticle(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(checkInArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC7_Verify_user_can_move_an_article_to_trash_section()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.TrashArticle(randomTitle);

            commonPage.WaitForPageLoading(10000);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(trashArticleSuccessMessage, getMessage);

            articleManagePage.searchArticle("", "Trashed", "", "", "", "", "", "");

            bool isTitleExistOnTable = articleManagePage.IsArticleExistOnTable(randomTitle);
            CheckTitleExistOnTable(isTitleExistOnTable);

        }

        [TestMethod]
        public void TC15_Verify_user_can_change_the_status_of_articles_using_the_Status_column()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.SelectTitle(randomTitle);

            articleManagePage.ChangeStatusByIcon(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unPublishArticleSuccessMessage, getMessage);

            articleManagePage.SelectTitle(randomTitle);

            articleManagePage.ChangeStatusByIcon(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(publishArticleSuccessMessage, getMessage);
        }

        [TestMethod]
        public void TC16_Verify_user_can_change_the_feature_property_of_articles_using_the_Featured_column()
        {
            articleManagePage.OpenNewArticlePage();

            articleNewPage = new ArticlesNew_Page();
            articleNewPage.CreateNewArticle(randomTitle, publishStatus, categoryArticle, content, saveAndClose, "", "", "");

            string getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(createArticleSuccessMessage, getMessage);

            articleManagePage.SelectTitle(randomTitle);

            articleManagePage.ChangeFeatureByIcon(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(featureArticleSuccessMessage, getMessage);

            articleManagePage.SelectTitle(randomTitle);

            articleManagePage.ChangeFeatureByIcon(randomTitle);

            getMessage = articleManagePage.getControlMessage(commonPage.alertNotify);
            CheckMessage(unFeatureArticleSuccessMessage, getMessage);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
