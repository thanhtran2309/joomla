using OpenQA.Selenium;
using System;
using ThanhTran_Joomla.Common;


namespace ThanhTran_Joomla.Pages
{
    class ArticlesNew_Page : Common_Page
    {
        #region Interface
        By titleXpath = By.XPath("//input[@id='jform_title']");
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
        By frameImageFather = By.XPath("//iframe[@src='https://qaservices1.joomla.com/administrator/index.php?option=com_media&view=images&tmpl=component&e_name=jform_articletext&asset=com_content&author=']");
        By frameImageSon = By.XPath("//iframe[@id='imageframe']");
        By insertButton = By.XPath("//button[text()='Insert' and @class='btn btn-success button-save-selected']");
        string image = "//a[@class='img-preview' and @title='{0}']/..";


        #endregion

        #region Method
        public void CreateNewArticle(string title, string status, string category, string content, string savetype, string featured, string language, string insertImage)
        {
            WaitForControl(frameXpath, longterm);
            //Enter title
            driver.FindElement(titleXpath).SendKeys(title);

            //Select feature
            if (featured == "Yes")
                driver.FindElement(yesFeatureButton).Click();

            //Select category
            if (category != "")
            {
                driver.FindElement(categoryDropdownXpath).Click();
                driver.FindElement(By.XPath("//div[@id='jform_catid_chzn']//li[contains(text(),'" + category + "')]")).Click();
            }

            //Select status
            if (status != "")
            {
                driver.FindElement(statusXpath).Click();
                driver.FindElement(By.XPath("//ul[@class='chzn-results']/li[text()='" + status + "']")).Click();
                //div[@id='jform_catid_chzn']//ul[@class='chzn-results']/li[text()='- catagory 1']
            }

            //Input content
            if (content != "")
            {
                driver.FindElement(frameXpath).Click();
                driver.FindElement(frameXpath).SendKeys(content);
            }

            //Insert image
            if (insertImage != "")
            {
                driver.FindElement(imageButton).Click();
                WaitForControl(frameImageFather, midterm);
                driver.SwitchTo().Frame(driver.FindElement(frameImageFather));
                WaitForControl(frameImageSon, midterm);
                driver.SwitchTo().Frame(driver.FindElement(frameImageSon));

                By imageControl = By.XPath(String.Format(image, insertImage));
                WaitForControl(imageControl, midterm);
                driver.FindElement(imageControl).Click();

                driver.SwitchTo().DefaultContent();

                driver.SwitchTo().Frame(driver.FindElement(frameImageFather));
                driver.FindElement(insertButton).Click();
                driver.SwitchTo().DefaultContent();
            }

            //Click Save or Save&close or Save&New
            if (savetype == "Save")
                driver.FindElement(saveButtonXpath).Click();
            else if (savetype == "Save and Close")
                driver.FindElement(saveAndCloseButtonXPath).Click();
            else if (savetype == "Save and New")
                driver.FindElement(saveAndNewButtonXPath).Click();


        }

        public void WaitForNewArticlePageLoading(int milisecond)
        {
            WaitForControl(frameXpath, milisecond);
        }
        #endregion
    }
}
