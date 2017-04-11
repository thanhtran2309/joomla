using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using OpenQA.Selenium.Support;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class Article : Common_Test

    {
        #region Declare
        Common_Page commonPage = new Common_Page();
        Login_Page loginPage = new Login_Page();
        Articles_Page articlePage = new Articles_Page();
        ArticlesNew_Page articleNewPage = new ArticlesNew_Page();
        ArticlesEdit_Page articleEditPage = new ArticlesEdit_Page();

        string publishStatus = "Published";
        string unPublishStatus = "Unpublished";
        string archiveStatus = "Archived";
        string category = "- Category 2";
        string guestAccess = "Guest";
        string author = "Thanh Tran";
        string contentEdit = " Edit rồi";
        string content = "Trần Chí Thành";
        string saveAndClose = "Save and Close";
        string categoryEdit = "- catagory 1";
        string randomTitle = null;

        #endregion

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContent)
        {
            Console.WriteLine("Run ClassInitialize");
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            Console.WriteLine("Run TestInitialize");

            randomTitle = RandomTitle();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            commonPage.openArticlePage();
        }

        [TestMethod]
        public void TC1_Verify_user_can_create_new_article_with_valid_information()
        {
            Console.WriteLine("Run TC1");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);
        }

        [TestMethod]
        public void TC2_Verify_user_can_edit_an_article()
        {
            Console.WriteLine("Run TC2");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            commonPage.openArticlePage();

            articlePage.ActionOnArticle("Edit", randomTitle);

            articleEditPage.EditArticle(randomTitle + " edit", publishStatus, category, contentEdit, saveAndClose);

            CheckSuccessAlertMessage(createSuccessMessage);

        }

        [TestMethod]
        public void TC3_Verify_user_can_publish_an_unpublished_article()
        {
            Console.WriteLine("Run TC3");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, unPublishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.ActionOnArticle("Publish", randomTitle);

            commonPage.WaitForPageLoading(10000);

            CheckSuccessAlertMessage(publishSuccessMessage);
        }

        [TestMethod]
        public void TC4_Verify_user_can_unpublish_a_published_article()
        {
            Console.WriteLine("Run TC4");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.ActionOnArticle("Unpublish", randomTitle);

            commonPage.WaitForPageLoading(10000);

            CheckSuccessAlertMessage(unPublishSuccessMessage);
        }

        [TestMethod]
        public void TC5_Verify_user_can_move_an_article_to_the_archive()
        {
            Console.WriteLine("Run TC5");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.ActionOnArticle("Archive", randomTitle);

            commonPage.WaitForPageLoading(10000);

            CheckSuccessAlertMessage(archiveSuccessMessage);

            articlePage.searchArticle("", archiveStatus, "", "", "", "", "", "");

            CheckArticleExistOnTable(randomTitle);

        }

        [TestMethod]
        public void TC6_Verify_user_can_check_in_an_article()
        {
            Console.WriteLine("Run TC6");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, "Save", "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            //commonPage.driver.Quit();
            commonPage.QuitBrowser();

            commonPage.NavigateJoomla();

            loginPage.Login(username, password);

            commonPage.openArticlePage();

            articlePage.ActionOnArticle("Check-in", randomTitle);

            CheckSuccessAlertMessage(checkInSuccessMessage);
        }

        [TestMethod]
        public void TC7_Verify_user_can_move_an_article_to_trash_section()
        {
            Console.WriteLine("Run TC7");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.ActionOnArticle("Trash", randomTitle);

            commonPage.WaitForPageLoading(10000);

            CheckSuccessAlertMessage(trashSuccessMessage);

            articlePage.searchArticle("", "Trashed", "", "", "", "", "", "");

            CheckArticleExistOnTable(randomTitle);


        }

        [TestMethod]
        public void TC8_Verify_user_can_access_article_help_section()
        {
            //Not done yet
            Thread.Sleep(5000);
            //Open Article Page

            commonPage.openArticlePage();
            Thread.Sleep(5000);

        }


        [TestMethod]
        public void TC9_Verify_user_can_search_for_articles_using_the_filter_text_field()
        {
            Console.WriteLine("Run TC9");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.searchArticle(randomTitle, "", "", "", "", "", "", "");

            CheckArticleExistOnTable(randomTitle);

        }

        [TestMethod]
        public void TC10_Verify_user_can_search_for_articles_using_the_filter_dropdown_lists()
        {
            Console.WriteLine("Run TC10");

            articlePage.OpenNewArticlePage();

            articleNewPage.CreateNewArticle(randomTitle, publishStatus, category, content, saveAndClose, "", "", "");

            CheckSuccessAlertMessage(createSuccessMessage);

            articlePage.searchArticle("", publishStatus, category, guestAccess, author, "", "", "");

            CheckArticleExistOnTable(randomTitle);
        }

        [TestMethod]
        public void TC11_Verify_user_can_sort_the_article_table_by_ID_column()
        {
            commonPage.WaitForPageLoading(10000);
            articlePage.ClickIDbutton();
            CheckSortFollow("Ascending");
            articlePage.ClickIDbutton();
            CheckSortFollow("Descending");
        }


        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            //commonPage.driver.Quit();
            commonPage.QuitBrowser();
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            Console.WriteLine("Run ClassCleanup");
        }

    }
}
