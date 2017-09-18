using OpenQA.Selenium;
using ThanhTran_Joomla.Common;



namespace ThanhTran_Joomla.Pages.Banners
{
    class ClientEdit_Page : Common_Page
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
        By contactNameTextField = By.XPath("//input[@id='jform_contact']");
        By emailTextField = By.XPath("//input[@id='jform_email']");
        #endregion

        #region Method      
        public void EditClient(string title, string status, string savetype, string name, string email)
        {
            WaitForControl(emailTextField, longterm);

            //Edit title
            if (title!="")
            {
                driver.FindElement(titleXpath).Clear();
                driver.FindElement(titleXpath).SendKeys(title);
            }

            //Select status
            if (status != "")
            {
                driver.FindElement(statusXpath).Click();
                driver.FindElement(By.XPath("//ul[@class='chzn-results']/li[text()='" + status + "']")).Click();
                //div[@id='jform_catid_chzn']//ul[@class='chzn-results']/li[text()='- catagory 1']
            }

            //Edit name
            if (name != "")
            {
                driver.FindElement(contactNameTextField).Clear();
                driver.FindElement(contactNameTextField).SendKeys(name);
            }

            //Edit email
            if (email != "")
            {
                driver.FindElement(emailTextField).Clear();
                driver.FindElement(emailTextField).SendKeys(email);
            }
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
