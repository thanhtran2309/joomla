using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;
using OpenQA.Selenium.Support;

namespace ThanhTran_Joomla.Pages
{
    public class Common_Test
    {

        #region Declare
        public string username = "ThanhTran";
        public string password = "antbuddy";

        public string createSuccessMessage = "Article successfully saved.";
        public string publishSuccessMessage = "1 article published.";
        public string unPublishSuccessMessage = "1 article unpublished.";
        public string archiveSuccessMessage = "1 article archived.";
        public string checkInSuccessMessage = "1 article successfully checked in.";
        public string trashSuccessMessage = "1 article trashed.";

        //By createSuccessNotify = By.XPath("//div[@class='alert-message' and text()='Article successfully saved.']");
        //By publishSuccessNotify = By.XPath("//div[@class='alert-message' and text()='1 article published.']");
        //By unPublishSuccessNotify = By.XPath("//div[@class='alert-message' and text()='1 article unpublished.']");
        //By archiveSuccessNotify = By.XPath("//div[@class='alert-message' and text()='1 article archived.']");
        //By checkInSuccessNotify = By.XPath("//div[@class='alert-message' and text()='1 article successfully checked in.']");
        //By trashSuccessNotify = By.XPath("//div[@class='alert-message' and text()='1 article trashed.']");
        By successAlert = By.XPath("//div[@class='alert alert-success']/div[@class='alert-message']");

        Articles_Page articlePage = new Articles_Page();
        Common_Page commonPage = new Common_Page();
        #endregion

        #region Method

        public string RandomTitle()
        {
            string randomTitle;
            return randomTitle = DateTime.Now.ToString("ddMMyyhhmmss") + " lần nhớ em";
        }

        //Check isAscending
        public void CheckSortFollow(string type)
        {
            if (type == "Ascending")
                Assert.IsTrue(articlePage.IsAscending());
            if (type == "Descending")
                Assert.IsFalse(articlePage.IsAscending());

        }

        //Check success notify display
        public void CheckSuccessAlertMessage(string message)
        {
            //Check whether texts are same each other
            string getMessage = commonPage.GetText(successAlert);
            Assert.IsTrue(CompareText(message, getMessage));
        }


        //Compare text of 2 strings
        public bool CompareText(string text1, string text2)
        {
            if (text1 == text2)
                return true;
            else
                return false;
        }

        //Verify article exist on table
        public void CheckArticleExistOnTable(string title)
        {
            articlePage.SelectDisplayRow("All");
            articlePage.WaitForTableLoading(10000);
            By elementTitle = By.XPath("//a[contains(text(),'" + title + "')]");
            Assert.IsTrue(commonPage.IsElementExist(elementTitle) == true);
        }

        #endregion
    }
}
