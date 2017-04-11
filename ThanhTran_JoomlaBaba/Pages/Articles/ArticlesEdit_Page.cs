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
    class ArticlesEdit_Page : Common_Page
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

        #endregion

        #region Method
        public void EditArticle(string title, string status, string category, string content, string savetype)
        {
            WaitForEditArticlePageLoading(10000);
            //Edit title
            driver.FindElement(titleXpath).Clear();
            driver.FindElement(titleXpath).SendKeys(title);

            //Select category
            driver.FindElement(categoryDropdownXpath).Click();
            driver.FindElement(By.XPath("//div[@id='jform_catid_chzn']//li[contains(text(),'" + category + "')]")).Click();

            //Select status
            driver.FindElement(statusXpath).Click();
            driver.FindElement(By.XPath("//ul[@class='chzn-results']/li[text()='" + status + "']")).Click();

            //Input content
            driver.FindElement(frameXpath).Click();
            //driver.FindElement(By.XPath(frameXpath)).Clear();
            driver.FindElement(frameXpath).SendKeys(content);

            //Click Save or Save&close or Save&New
            if (savetype == "Save")
                driver.FindElement(saveButtonXpath).Click();
            else if (savetype == "Save and Close")
                driver.FindElement(saveAndCloseButtonXPath).Click();
            else if (savetype == "Save and New")
                driver.FindElement(saveAndNewButtonXPath).Click();
        }

        public void WaitForEditArticlePageLoading(int milisecond)
        {
            WaitForControl(frameXpath, milisecond);
        }
        #endregion

    }
}
