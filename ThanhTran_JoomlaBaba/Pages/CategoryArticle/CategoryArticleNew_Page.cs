using OpenQA.Selenium;
using System;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla.Pages
{
    class CategoryArticleNew_Page : Common_Page
    {
        #region Interface
        public By titleTextField = By.XPath("//input[@id='jform_title']");
        By categoryDropdownXpath = By.XPath("//div[@id='jform_catid_chzn']/a");
        By frameXpath = By.XPath("//iframe[@id='jform_articletext_ifr']");
        By statusXpath = By.XPath("//a[@class='chzn-single chzn-color-state']");
        By saveButtonXpath = By.XPath("//div[@id='toolbar-apply']/button");
        By saveAndCloseButtonXPath = By.XPath("//div[@id='toolbar-save']/button");
        By saveAndNewButtonXPath = By.XPath("//div[@id='toolbar-save-new']/button");
        By cancelButtonXpath = By.XPath("//div[@id='toolbar-cancel']/button");
        By createSuccessNotify = By.XPath("//div[@class='alert-message' and text()= 'Article successfully saved.']");
        By yesFeatureButton = By.XPath("//label[@class='btn' and contains(text(),'Yes')]");
        By noFeatureButton = By.XPath("//label[@class ='btn active btn-danger' and contains(text(),'No')]");
        By imageButton = By.XPath("//button[@role='presentation']/span[text()='Image']");
        By contactNameTextField = By.XPath("//input[@id='jform_contact']");
        By clientDropdown = By.XPath("//div[@id='jform_cid_chzn']/a");
        By clientTextField = By.XPath("//div[@id='jform_cid_chzn']//input");
        public By emailTextField = By.XPath("//input[@id='jform_email']");

        #endregion

        #region Method
        public void CreateNewCategoryArticle(string title, string status, string savetype, string parrent)
        {
            WaitForControl(statusXpath, longterm);
            //Enter title
            driver.FindElement(titleTextField).SendKeys(title);

            //Select status
            if (status != "")
            {
                driver.FindElement(statusXpath).Click();
                driver.FindElement(By.XPath("//ul[@class='chzn-results']/li[text()='" + status + "']")).Click();
            }

            //Select parrent
            if (parrent != "")
            {
            }


            //Click Save or Save&close or Save&New
            if (savetype == "Save")
                driver.FindElement(saveButtonXpath).Click();
            else if (savetype == "Save and Close")
                driver.FindElement(saveAndCloseButtonXPath).Click();
            else if (savetype == "Save and New")
                driver.FindElement(saveAndNewButtonXPath).Click();
        }

        public void OpenCategoryArticleNewHelpPage()
        {
            WaitForPageLoading(midterm);
            OpenHelpPage();
        }

        #endregion
    }
}
