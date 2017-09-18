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
using OpenQA.Selenium.Interactions;


namespace ThanhTran_Joomla.Common
{
    class ControlPanel_Page:Common_Page
    {
        #region Interface
        public By contentMenuXpath = By.XPath("//a[contains(text(),'Content')][@class='dropdown-toggle']");
        public By componentMenuXpath = By.XPath("//a[contains(text(),'Components')][@class='dropdown-toggle']");
        public By articlesSubmenuXpath = By.XPath("//a[@class='dropdown-toggle menu-article' and .='Articles']");
        public By contactSubmenuXpath = By.XPath("//a[@class='dropdown-toggle menu-contact' and text()='Contacts']");
        public By bannerSubmenuXpath = By.XPath("//a[@class='dropdown-toggle menu-banners' and text()='Banners']");
        public By categorySubmenuXpath = By.XPath("//a[@class='dropdown-toggle menu-category' and text()='Categories']");


        #endregion

        #region Method
        public void OpenArticlePage()
        {
            WaitForControl(contentMenuXpath, longterm);
            driver.FindElement(contentMenuXpath).Click();
            Thread.Sleep(500);// Wait for button appear
            driver.FindElement(articlesSubmenuXpath).Click();
        }

        public void OpenCategoryArticlePage()
        {
            WaitForControl(contentMenuXpath, longterm);
            driver.FindElement(contentMenuXpath).Click();
            Thread.Sleep(500);// Wait for button appear
            driver.FindElement(categorySubmenuXpath).Click();
        }

        public void OpenContactPage()
        {
            WaitForControl(componentMenuXpath, longterm);
            driver.FindElement(componentMenuXpath).Click();
            Thread.Sleep(500);// Wait for button appear
            driver.FindElement(contactSubmenuXpath).Click();
        }

        public void OpenBannerPage()
        {
            WaitForControl(componentMenuXpath, longterm);
            driver.FindElement(componentMenuXpath).Click();
            Thread.Sleep(500);// Wait for button appear
            driver.FindElement(bannerSubmenuXpath).Click();
        }

        public void Hovering()
        {
            driver.FindElement(contentMenuXpath).Click();
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(articlesSubmenuXpath)).Click().Build().Perform();
        }
        #endregion
    }
}
