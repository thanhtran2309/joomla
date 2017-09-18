using OpenQA.Selenium;
using ThanhTran_Joomla.Common;



namespace ThanhTran_Joomla.Pages
{
    class ContactEdit_Page : Common_Page
    {
        #region Interface
        By titleXpath = By.XPath("//input[@id='jform_name']");
        By categoryDropdownXpath = By.XPath("//div[@id='jform_catid_chzn']/a");
        By frameXpath = By.XPath("//iframe[@id='jform_articletext_ifr']");
        By statusXpath = By.XPath("//a[@class='chzn-single chzn-color-state']");
        By saveButtonXpath = By.XPath("//div[@id='toolbar-apply']/button");
        By saveAndCloseButtonXPath = By.XPath("//div[@id='toolbar-save']/button");
        By saveAndNewButtonXPath = By.XPath("//div[@id='toolbar-save-new']/button");
        By cancelButtonXpath = By.XPath("//div[@id='toolbar-cancel']/button");
        By yesFeatureButton = By.XPath("//label[@class='btn' and contains(text(),'Yes')]");
        By noFeatureButton = By.XPath("//label[@class ='btn active btn-danger' and contains(text(),'No')]");

        #endregion

        #region Method
        public void EditContact(string title, string status, string category, string savetype, string featured, string language, string insertImage)
        {
            WaitForControl(categoryDropdownXpath, longterm);

            //Edit title
            if (title!="")
            {
                driver.FindElement(titleXpath).Clear();
                driver.FindElement(titleXpath).SendKeys(title);
            }

            //Select feature
            if (featured == "Yes")
                driver.FindElement(yesFeatureButton).Click();
            if (featured == "No")
                driver.FindElement(noFeatureButton).Click();

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

            ////Insert image
            //if (insertImage != "")
            //{
            //    driver.FindElement(imageButton).Click();
            //    WaitForControl(frameImage, longterm);
            //    driver.SwitchTo().Frame(driver.FindElement(frameImage));
            //    By imageControl = By.XPath(String.Format(image, insertImage));
            //    WaitForControl(imageControl, longterm);
            //    driver.FindElement(imageControl).Click();
            //    driver.FindElement(insertButton).Click();
            //    driver.SwitchTo().DefaultContent();
            //}

            //Click Save or Save&close or Save&New
            if (savetype == "Save")
                driver.FindElement(saveButtonXpath).Click();
            else if (savetype == "Save and Close")
                driver.FindElement(saveAndCloseButtonXPath).Click();
            else if (savetype == "Save and New")
                driver.FindElement(saveAndNewButtonXPath).Click();
        }
        #endregion

    }
}
