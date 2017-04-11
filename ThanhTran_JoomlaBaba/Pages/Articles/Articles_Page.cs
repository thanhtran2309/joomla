using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla.Pages
{
    public class Articles_Page : Common_Page
    {
        #region Interface
        By newButtonXpath = By.XPath("//div[@id='toolbar-new']/button");
        By editButtonXpath = By.XPath("//div[@id='toolbar-edit']/button");
        By publishButtonXpath = By.XPath("//div[@id='toolbar-publish']/button");
        By unpublishButtonXpath = By.XPath("//div[@id='toolbar-unpublish']/button");
        By featureButtonXpath = By.XPath("//div[@id='toolbar-featured']/button");
        By unfeatureButtonXpath = By.XPath("//div[@id='toolbar-unfeatured']/button");
        By archiveButtonXpath = By.XPath("//div[@id='toolbar-archive']/button");
        By checkinButtonXpath = By.XPath("//div[@id='toolbar-checkin']/button");
        By batchButtonXpath = By.XPath("//div[@id='toolbar-batch']/button");
        By trashButtonXpath = By.XPath("//div[@id='toolbar-trash']/button");
        By searchToolButton = By.XPath("//button[contains(text(),'Search Tools')]");
        By searchButton = By.XPath("//button[@type='submit']/span[@class='icon-search']");
        By clearButton = By.XPath("//button[@type='button' and contains(text(),'Clear')]");
        By selectStatusDropdown = By.XPath("//span[contains(text(),'Select Status')]");
        By selectCategoryDropdown = By.XPath("//span[contains(text(),'Select Category')]");
        By selectAccessDropdown = By.XPath("//span[contains(text(),'Select Access')]");
        By selectAuthorDropdown = By.XPath("//span[contains(text(),'Select Author')]");
        By selectLanguageDropdown = By.XPath("//span[contains(text(),'Select Language')]");
        By selectTagDropdown = By.XPath("//span[contains(text(),'Select Tag')]");
        By selectMaxLevelDropdown = By.XPath("//span[contains(text(),'Select Max Levels')]");
        By allDropdown = By.XPath("//*[@id='list_limit_chzn']/a[@class='chzn-single']");
        By searchBox = By.XPath("//input[@id='filter_search']");
        By idAscending = By.XPath("//a[@class='chzn-single']/span[text()='ID ascending']");
        By idDecending = By.XPath("//a[@class='chzn-single']/span[text()='ID descending']");
        By table = By.XPath("//table[@id='articleList']");
        By row = By.XPath("//table/tbody/tr");
        By lastCell = By.XPath("//table/tbody/tr[last()]/td[last()]");
        By sortById = By.XPath("//a[@data-name='ID'and contains(text(),'ID')]");
        By checkAllbutton = By.XPath("//input[@name='checkall-toggle']");

        #endregion


        #region Method

        //Click on ID button
        public void ClickIDbutton()
        {
            driver.FindElement(sortById).Click();
            WaitForPageLoading(10000);
        }
        
        //CountRow
        public int CountRow()
        {
            int rowNumber = driver.FindElements(row).Count();
            return rowNumber;
        }

        //Check ascending
        public bool IsAscending()
        {
            int n = CountRow();
            Console.WriteLine("n= " + n);
            int i = 1;
            int j = i + 1;
            while (i < n)
            {
                int value1 = Convert.ToInt32(driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[last()]")).Text);
                Console.WriteLine("value 1 " + value1 + "lan " + i);
                int value2 = Convert.ToInt32(driver.FindElement(By.XPath("//table/tbody/tr[" + j + "]/td[last()]")).Text);
                Console.WriteLine("value 2 " + value2 + "lan " + j);
                i = i + 1;
                j = i + 1;
                if (value1 > value2)
                    return false;
            }
            return true;
        }

        public void WaitForArticlePageLoading(int milisecond)
        {
            WaitForControl(table, milisecond);
            Thread.Sleep(500);
        }

        //Action on article
        public void ActionOnArticle(string action, string title)
        {
            if (action == "Edit")
                OpenEditArticlePage(title);
            else if (action == "Publish")
                PublishArticle(title);
            else if (action == "Unpublish")
                UnpublishArticle(title);
            else if (action == "Feature")
                FeatureArticle(title);
            else if (action == "Unfeature")
                UnfeatureArticle(title);
            else if (action == "Archive")
                ArchiveArticle(title);
            else if (action == "Check-in")
                CheckInArticle(title);
            else if (action == "Batch")
                BatchArticle(title);
            else if (action == "Trash")
                TrashArticle(title);
        }

        //Trash article
        public void TrashArticle(string title)
        {
            SelectTitle(title);
            driver.FindElement(trashButtonXpath).Click();
        }

        //Batch article
        public void BatchArticle(string title)
        {

        }

        //Check-in article
        public void CheckInArticle(string title)
        {
            SelectTitle(title);
            driver.FindElement(checkinButtonXpath).Click();
        }

        //Open new article Page
        public void OpenNewArticlePage()
        {
            WaitForArticlePageLoading(10000);
            driver.FindElement(newButtonXpath).Click();
        }

        //Select title
        public void SelectTitle(string title)
        {
            WaitForArticlePageLoading(10000);
            driver.FindElement(By.XPath("//div[@class='pull-left break-word']/a[contains(text(),'" + title + "')]/../../..//input[@name='cid[]']")).Click();
        }

        // Open Edit article Page
        public void OpenEditArticlePage(string title)
        {
            SelectTitle(title);
            driver.FindElement(editButtonXpath).Click();
        }

        //Publish Article
        public void PublishArticle(string title)
        {
            //Check is article publishing??
            if (IsArticlePublish(title) == false)
            {
                SelectTitle(title);
                driver.FindElement(publishButtonXpath).Click();
            }
            else;
        }

        //Unpublish Article
        public void UnpublishArticle(string title)
        {
            //Check is article publishing??
            if (IsArticlePublish(title) == true)
            {
                SelectTitle(title);
                driver.FindElement(unpublishButtonXpath).Click();
            }
            else;
        }

        //Feature Article
        public void FeatureArticle(string title)
        {
            //Check is article publishing??
            if (IsArticleFeature(title) == false)
            {
                SelectTitle(title);
                driver.FindElement(featureButtonXpath).Click();
            }
            else;
        }

        //Unfeature Article
        public void UnfeatureArticle(string title)
        {
            //Check is article publishing??
            if (IsArticleFeature(title) == true)
            {
                SelectTitle(title);
                driver.FindElement(unfeatureButtonXpath).Click();
            }
            else;
        }

        //Archive article
        public void ArchiveArticle(string title)
        {
            SelectTitle(title);
            driver.FindElement(archiveButtonXpath).Click();
        }



        //Check is article publish or not
        public bool IsArticlePublish(string title)
        {
            By publishIconXpath = By.XPath("//div[@class='pull-left break-word']/a[contains(text(),'" + title + "')]/../../..//span[@class='icon-publish']");
            if (IsElementExist(publishIconXpath) == true)
                return true;
            else
                return false;
        }

        //Check is article feature or not
        public bool IsArticleFeature(string title)
        {
            By publishIconXpath = By.XPath("//div[@class='pull-left break-word']/a[contains(text(),'" + title + "')]/../../..//span[@class='icon-featured']");
            if (IsElementExist(publishIconXpath) == true)
                return true;
            else
                return false;
        }



        //Search feature
        public void searchArticle(string title, string status, string category, string access, string author, string language, string tag, string maxlevel)
        {
            driver.FindElement(searchToolButton).Click();
            Thread.Sleep(1000);

            if (title != "")
            {
                driver.FindElement(searchBox).SendKeys(title);
                driver.FindElement(searchButton).Click();
            }

            if (status != "")
            {
                driver.FindElement(selectStatusDropdown).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//ul[@class='chzn-results']/li[text()='" + status + "']")).Click();

                //ul[@class='chzn-results']/li[text()='Archived']
            }

            if (category != "")
            {
                driver.FindElement(selectCategoryDropdown).Click();
            }

            if (access != "")
            {

            }
            if (author != "")
            {

            }
            if (language != "")
            {

            }
            if (tag != "")
            {

            }
            if (maxlevel != "")
            {

            }

        }

        public void SelectDisplayRow(string row)
        {
            driver.FindElement(allDropdown).Click();
            driver.FindElement(By.XPath("//div[@class='chzn-drop']/ul[@class='chzn-results']/li[text()='" + row + "']")).Click();
        }

        public void WaitForTableLoading(int milisecond)
        {
            WaitForControl(lastCell, 10000);
            int i = 0;

            Console.WriteLine("Last cell text= " + driver.FindElement(lastCell).Text);

            while (driver.FindElement(lastCell).Text == "")
            {
                i = i + 1;
                Thread.Sleep(500);
                Console.WriteLine("Last cell text= " + driver.FindElement(lastCell).Text);
            }
        }

        //Wait for control/ Wait for element
        public void WaitForControl(By control, int milisecond)
        {
            double i = 0;
            while (i <= milisecond)
            {
                if (IsElementExist(control) == true)
                {
                    Thread.Sleep(800);
                    break;
                }
                else
                {
                    i = i + 500;
                    Thread.Sleep(500);
                }
            }
        }

        public void DeleteAllArticle()
        {
            while (true)
            {
                WaitForControl(checkAllbutton, 10000);
                SelectDisplayRow("10");
                driver.FindElement(checkAllbutton).Click();
                driver.FindElement(trashButtonXpath).Click();
                WaitForPageLoading(10000);
            }


        }
    }
    #endregion
}
