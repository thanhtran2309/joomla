using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        #endregion

        #region Method
        public void CreateNewArticle(string title, string status, string category, string content, string savetype, string featured, string language, string insertImage)
        {
            WaitForControl(frameXpath, 15000);
            Console.WriteLine("Input title");
            //Enter title
            driver.FindElement(titleXpath).SendKeys(title);

            //Select feature
            if (featured == "Yes")
                driver.FindElement(yesFeatureButton).Click();
            else if (featured == "No")
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

            //Input content
            if (content != "")
            {
                Thread.Sleep(1500);
                driver.FindElement(frameXpath).Click();
                driver.FindElement(frameXpath).SendKeys(content);
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
