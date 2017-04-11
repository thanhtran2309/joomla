using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThanhTran_Joomla.Common
{
    public class Common_Page
    {
        public static IWebDriver driver;

        public string url = "https://qaservices1.joomla.com/administrator";

        public By contentMenuXpath = By.XPath("//a[contains(text(),'Content')][@class='dropdown-toggle']");
        public By articlesSubmenuXpath = By.XPath("//a[@class='dropdown-toggle menu-article' and .='Articles']");
        public By logoutButton = By.XPath("//div[@class='btn-group logout']");

        public string randomTitle1 = DateTime.Now.ToString("ddMMyyhhmmss") + " lần nhớ em";

        public void NavigateJoomla()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(url);
        }

        public void QuitBrowser()
        {
            driver.Quit();
        }

        public void openArticlePage()
        {
            WaitForControl(contentMenuXpath, 10000);
            driver.FindElement(contentMenuXpath).Click();
            driver.FindElement(articlesSubmenuXpath).Click();
        }

        public void OpenBrowser()
        {

        }

        public bool IsElementExist(By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForPageLoading(int second)
        {
            Console.WriteLine("Wait for page load nha");
            //wait cho logout disappear
            WaitForControlDisappear(logoutButton, second);

            //Wait for logout display
            WaitForControl(logoutButton, second);
        }

        public void WaitForControlDisappear(By control, int milisecond)
        {
            double i = 0;
            //int n = second *100;
            Console.WriteLine("Wait for Logout disappear nha");
            while (i <= milisecond)
            {
                if (IsElementExist(control) == true)
                {
                    Console.WriteLine("Not disappear yet, i= " + i);
                    i = i + 50;
                    Thread.Sleep(50);
                }
                else
                {
                    Console.WriteLine("Logout is disappear");
                    break;
                }
            }
        }

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

        //Get text by element
        public string GetText(By element)
        {
            string getMessage = "";
            WaitForControl(element, 10000);
            try
            {
                getMessage = driver.FindElement(element).Text;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No element is founded");
            }
            return getMessage;
        }

        //Scroll to control
        public void ScrollToControl(By control)
        {
            var element = driver.FindElement(control);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
