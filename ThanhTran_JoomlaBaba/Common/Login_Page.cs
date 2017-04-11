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
    class Login_Page : Common_Page
    {
        #region Interface
        //IWebElement username_field = driver.FindElement(By.Id("mod-login-username"));
        //IWebElement password_field = driver.FindElement(By.Id("mod-login-password"));
        //IWebElement login_button = driver.FindElement(By.ClassName("btn btn-primary btn-block btn-large"));
        By usernameFieldXpath = By.XPath("//input[@id='mod-login-username']");
        By passwordFieldXpath = By.XPath("//input[@id='mod-login-password']");
        By loginButtonXpath = By.XPath("//button[@class='btn btn-primary btn-block btn-large']");
        #endregion

        #region Method
        public void Login(string username, string password)
        {
            driver.FindElement(usernameFieldXpath).SendKeys(username);
            driver.FindElement(passwordFieldXpath).SendKeys(password);
            driver.FindElement(loginButtonXpath).Click();
        }
        #endregion
    }
}
