
using OpenQA.Selenium;
using System.Threading;
using ThanhTran_Joomla.Common;
using System;
using System.Linq;

namespace ThanhTran_Joomla.Pages
{
    class BannerManage_Page : Common_Page
    {
        #region Variable of Manage common Page
        //Manage Page
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
        By selectClientDropdown = By.XPath("//span[contains(text(),'Select Client')]");
        By selectAuthorDropdown = By.XPath("//span[contains(text(),'Select Author')]");
        By selectLanguageDropdown = By.XPath("//span[contains(text(),'Select Language')]");
        By selectTagDropdown = By.XPath("//span[contains(text(),'Select Tag')]");
        By selectMaxLevelDropdown = By.XPath("//span[contains(text(),'Select Max Levels')]");
        By allDropdown = By.XPath("//div[@id='list_limit_chzn']/a[@class='chzn-single']");
        By searchBox = By.XPath("//input[@id='filter_search']");
        By idAscending = By.XPath("//a[@class='chzn-single']/span[text()='ID ascending']");
        By idDecending = By.XPath("//a[@class='chzn-single']/span[text()='ID descending']");
        By table = By.XPath("//table[@class='table table-striped']");
        By lastCell = By.XPath("//table/tbody/tr[last()]/td[last()]");
        By sortById = By.XPath("//a[@data-name='ID'and contains(text(),'ID')]");
        By checkAllbutton = By.XPath("//input[@name='checkall-toggle']");
        By checkOutIcon = By.XPath("//span[@class='icon-checkedout']");
        By sortByTableDropdown = By.XPath("//div[@id='list_fullordering_chzn']/a[@class='chzn-single']");
        By sortByTableTextBox = By.XPath("//div[@id='list_fullordering_chzn']//div[@class='chzn-search']/input");
        By selectCategoryTextField = By.XPath("//div[@id='filter_category_id_chzn']//input");
        By selectClientTextField = By.XPath("//div[@id='filter_client_id_chzn']//input");
        string checkbox = "//div[contains(@class,'pull-left')]/a[contains(text(),'{0}')]/../../..//input[@name='cid[]']";
        string statusIcon = "//div[contains(@class,'pull-left')]/a[contains(text(),'{0}')]/../../..//span[@class='icon-publish' or @class ='icon-unpublish']";
        string featureIcon = "//div[contains(@class,'pull-left')]/a[contains(text(),'{0}')]/../../..//span[@class='icon-featured' or @class ='icon-unfeatured']";
        string publishIcon = "//div[contains(@class,'pull-left')]/a[contains(text(),'{0}')]/../../..//span[@class='icon-publish']";
        string featuredIcon = "//div[contains(@class,'pull-left')]/a[contains(text(),'{0}')]/../../..//span[@class='icon-featured']";
        string filterSelection = "//ul[@class='chzn-results']/li[contains(text(),'{0}')]";
        string sortTableBySelection = "//ul[@class='chzn-results']/li[contains(text(),'{0}')]";


        #endregion

        #region Method of Manage Common Page



        //
        //Is Banner exist on table
        public bool IsBannerExistOnTable(string title)
        {
            WaitForPageLoading(midterm);
            By elementTitle = By.XPath("//a[contains(text(),'" + title + "')]");

            if (IsControlExist(elementTitle) == true)
                return IsControlExist(elementTitle);
            else
            {
                SortTableBy("ID descending");
                WaitForPageLoading(midterm);
                return IsControlExist(elementTitle);
            }
        }

        //Select title
        public void SelectTitle(string title)
        {
            //WaitForManagePageLoading(midterm);
            WaitForPageLoading(midterm);
            By checkboxTitle = By.XPath(string.Format(checkbox, title));
            if (IsControlExist(checkboxTitle) == false)
            {
                SortTableBy("ID descending");
            }
            WaitForControl(checkboxTitle, midterm);
            driver.FindElement(checkboxTitle).Click();
        }

        //------------------------------------------------------

        public void WaitForManagePageLoading(int milisecond)
        {
            WaitForControl(table, milisecond);
            //Thread.Sleep(500);
        }

        //Trash Banner
        public void TrashBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(trashButtonXpath).Click();
        }

        //Batch Banner
        public void BatchBanner(string title)
        {

        }

        //Check-in Banner
        public void CheckInBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(checkinButtonXpath).Click();
        }

        //Open new Banner Page
        public void OpenNewPage()
        {
            WaitForPageLoading(midterm);
            driver.FindElement(newButtonXpath).Click();
        }

        //Sort table by
        public void SortTableBy(string by)
        {
            WaitForControl(sortByTableDropdown, longterm);
            driver.FindElement(sortByTableDropdown).Click();
            driver.FindElement(sortByTableTextBox).SendKeys(by);
            driver.FindElement(sortByTableTextBox).SendKeys(Keys.Enter);
        }



        // Open Edit Banner Page
        public void OpenEditPage(string title)
        {
            SelectTitle(title);
            driver.FindElement(editButtonXpath).Click();
        }

        //Publish Banner
        public void PublishBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(publishButtonXpath).Click();
        }

        //Unpublish Banner
        public void UnpublishBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(unpublishButtonXpath).Click();

        }

        //Feature Banner
        public void FeatureBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(featureButtonXpath).Click();
        }

        //Unfeature Banner
        public void UnfeatureBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(unfeatureButtonXpath).Click();
        }

        //Archive Banner
        public void ArchiveBanner(string title)
        {
            SelectTitle(title);
            driver.FindElement(archiveButtonXpath).Click();
        }



        //Check is Banner publish or not
        public bool IsBannerPublish(string title)
        {
            By publishIconXpath = By.XPath(string.Format(publishIcon, title));
            WaitForControl(publishIconXpath, midterm);
            if (IsControlExist(publishIconXpath) == true)
                return true;
            else
                return false;
        }

        //Check is Banner unpublish or not
        public bool IsBannerUnPublish(string title)
        {
            bool isBannerPublish = IsBannerPublish(title);
            if (isBannerPublish == true)
                return false;
            else return true;
        }

        //Check is Banner feature or not
        public bool IsBannerFeature(string title)
        {
            By featureIconXpath = By.XPath(string.Format(featuredIcon, title));
            WaitForControl(featureButtonXpath, midterm);
            if (IsControlExist(featureIconXpath) == true)
                return true;
            else
                return false;
        }

        //Check is Banner unpublish or not
        public bool IsBannerUnFeature(string title)
        {
            bool isBannerFeature = IsBannerFeature(title);
            if (isBannerFeature == true)
                return false;
            else return true;
        }


        //Search feature
        public void searchBanner(string title, string status, string category, string client)
        {
            driver.FindElement(searchToolButton).Click();
            Thread.Sleep(1000);//Wait for buttons appear

            if (title != "")
            {
                driver.FindElement(searchBox).SendKeys(title);
                driver.FindElement(searchButton).Click();
            }

            if (status != "")
            {
                WaitForPageLoading(shortterm);
                driver.FindElement(selectStatusDropdown).Click();
                Thread.Sleep(500);//Wait for buttons appear
                By selection = By.XPath(string.Format(filterSelection, status));
                driver.FindElement(selection).Click();
            }

            if (category != "")
            {
                WaitForPageLoading(shortterm);
                SelectValueInDropdown(selectCategoryDropdown,selectCategoryTextField,category);
            }

            if (client != "")
            {
                WaitForPageLoading(shortterm);
                SelectValueInDropdown(selectClientDropdown, selectClientDropdown, client);
            }

        }

        public void SelectDisplayRow(string row)
        {
            WaitForPageLoading(midterm);
            WaitForControl(allDropdown, longterm);
            driver.FindElement(allDropdown).Click();
            driver.FindElement(By.XPath("//div[@class='chzn-drop']/ul[@class='chzn-results']/li[text()='" + row + "']")).Click();
        }

        public void WaitForTableLoading(int milisecond)
        {
            WaitForControl(lastCell, longterm);
            int i = 0;

            Console.WriteLine("Last cell text= " + driver.FindElement(lastCell).Text);

            while (driver.FindElement(lastCell).Text == "")
            {
                i = i + 1;
                Thread.Sleep(500);
                Console.WriteLine("Last cell text= " + driver.FindElement(lastCell).Text);
            }
        }

        ////Wait for control/ Wait for element
        //public void WaitForControl(By control, int milisecond)
        //{
        //    double i = 0;
        //    while (i <= milisecond)
        //    {
        //        if (IsControlExist(control) == true)
        //        {
        //            Thread.Sleep(800);
        //            break;
        //        }
        //        else
        //        {
        //            i = i + 500;
        //            Thread.Sleep(500);
        //        }
        //    }
        //}

        public void DeleteAllBanner()
        {
            while (true)
            {
                WaitForControl(checkAllbutton, longterm);
                if (IsControlExist(checkOutIcon))
                    driver.FindElement(checkOutIcon).Click();
                //driver.FindElement(By.XPath("//input[@name='cid[]']")).Click();
                driver.FindElement(checkAllbutton).Click();
                driver.FindElement(trashButtonXpath).Click();
                WaitForPageLoading(longterm);
            }
        }


        public void OpenBrowser()
        {

        }

        //Change status by clicking on icon
        public void ChangeStatusByIcon(string inputBanner)
        {
            By by = By.XPath(String.Format(statusIcon, inputBanner));
            driver.FindElement(by).Click();
            //WaitForPageLoading(longterm);
        }

        //Change status by clicking on icon
        public void ChangeFeatureByIcon(string inputBanner)
        {
            By by = By.XPath(String.Format(featureIcon, inputBanner));
            driver.FindElement(by).Click();
            //WaitForPageLoading(longterm);
        }

        //Is row number displays equal to number input?
        public bool IsRowDisplayEqualtoInput()
        {

            if (getControlMessage(allDropdown) == CountRow().ToString())
            {
                return true;
            }
            return false;
        }

        //Click on ID button
        public void ClickIDbutton()
        {
            WaitForControl(sortById, longterm);
            driver.FindElement(sortById).Click();
        }

        //Check ascending follow ID column

        public void OpenNewBannerPage()
        {
            OpenNewPage();
        }
    }
    #endregion


}
