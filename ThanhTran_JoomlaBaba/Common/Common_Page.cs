using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace ThanhTran_Joomla.Common
{
    public class Common_Page
    {
        public static IWebDriver driver;

        public string url = "https://qaservices1.joomla.com/administrator";

        public By logoutButton = By.XPath("//div[@class='btn-group logout']");
        public By helpButton = By.XPath("//div[@id='toolbar-help']");
        public By row = By.XPath("//table/tbody/tr");
        public By alertNotify = By.XPath("//div[@class='alert alert-success']/div[@class='alert-message']");
        public By clientSubMenu = By.XPath("//ul[@id='submenu']//a[contains(text(),'Clients')]");
        public By cateogorySubMenu = By.XPath("//ul[@id='submenu']//a[contains(text(),'Categories')]");
        public By bannerSubMenu = By.XPath("//ul[@id='submenu']//a[contains(text(),'Banners')]");

        public int longterm = 15000;
        public int midterm = 5000;
        public int shortterm = 1500;
        public string browser = "Chrome"; //Change browser here

        public string randomTitle1;

        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range range;

        public void openExcel()
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"d:\csharp-Excel.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        }

        #region Method of common page

        //Is title window exist
        public bool IsTitleWindowExist(string expectedNewWindowTitle)
        {
            string parentWindow = "";
            string newWindow = "";
            Thread.Sleep(5000);//Wait all window display
            IList<string> allWindowHandles = driver.WindowHandles;
            parentWindow = driver.CurrentWindowHandle;
            //Get new window handle
            for (int i = 0; i < allWindowHandles.Count; i++)
            {
                if (allWindowHandles[i] != parentWindow)
                {
                    newWindow = allWindowHandles[i];
                }
            }
            //Switch to new window handle.
            driver.SwitchTo().Window(newWindow);
            By titleXpath = By.XPath("html/body/h1");
            string titleString = driver.FindElement(titleXpath).Text;
            Console.WriteLine("New Window Title: " + titleString);
            if (titleString.Contains(expectedNewWindowTitle)==true)
            {
                driver.SwitchTo().DefaultContent();
                return true;
            }
            driver.SwitchTo().DefaultContent();
            return false;
            //back to default driver
        }

        //Select value in dropdown
        public void SelectValueInDropdown(By dropdown,By textfield, string value)
        {
            driver.FindElement(dropdown).Click();
            Thread.Sleep(500);//Wait for textfield display

            driver.FindElement(textfield).SendKeys(value);
            driver.FindElement(textfield).SendKeys(Keys.Enter);
        }

        // Open Clients page
        public void OpenClientPage()
        {
            WaitForControl(clientSubMenu, midterm);
            driver.FindElement(clientSubMenu).Click();
        }

        // Open Category page
        public void OpenCategoryPage()
        {
            WaitForControl(cateogorySubMenu, midterm);
            driver.FindElement(cateogorySubMenu).Click();
        }

        // Open Banners page
        public void OpenBannerPage()
        {
            WaitForControl(bannerSubMenu, midterm);
            driver.FindElement(bannerSubMenu).Click();
        }

        //Is control change to red?
        public bool IsControlChangeToRed(By control)
        {
            string a = driver.FindElement(control).GetAttribute("aria-invalid");
            if (a == "true")
                return true;
            else
                return false;
        }

        public void NavigateJoomla()
        {
            if (browser == "Firefox")
                driver = new FirefoxDriver();
            if (browser == "Chrome")
                driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public void QuitBrowser()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
        }

        //Open help page
        public void OpenHelpPage()
        {
            WaitForControl(helpButton, longterm);
            driver.FindElement(helpButton).Click();
        }

        //Get text by element
        public string getControlMessage(By element)
        {
            WaitForPageLoading(shortterm);
            string getMessage = "";
            WaitForControl(element, longterm);
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

        //Is page is displaying
        public bool IsPageDisplaying(string expectedNewWindowTitle)
        {
            string parentWindow = "";
            string newWindow = "";
            Thread.Sleep(5000);//Wait all window display
            IList<string> allWindowHandles = driver.WindowHandles;
            parentWindow = driver.CurrentWindowHandle;
            //Get new window handle
            for (int i = 0; i < allWindowHandles.Count; i++)
            {
                if (allWindowHandles[i] != parentWindow)
                {
                    newWindow = allWindowHandles[i];
                }
            }
            //Switch to new window handle.
            driver.SwitchTo().Window(newWindow);
            Console.WriteLine("New Window Title: " + driver.Title);
            if (expectedNewWindowTitle == driver.Title)
            {
                driver.SwitchTo().DefaultContent();
                return true;
            }
            driver.SwitchTo().DefaultContent();
            return false;
            //back to default driver
        }

        //Is parentPage displaying
        public bool IsCurrentWindowPageDisplaying(string title)
        {
            WaitForPageLoading(midterm);
            bool abc = driver.Title.Contains(title);
            return abc;
        }

        public bool IsControlExist(By element)
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
            //wait cho logout disappear
            WaitForControlDisappear(logoutButton, second);

            //Wait for logout display
            WaitForControl(logoutButton, second);
        }
        
        public void WaitForControlDisappear(By control, int milisecond)
        {
            double i = 0;
            //int n = second *100;
            while (i <= milisecond)
            {
                if (IsControlExist(control) == true)
                {
                    i = i + 50;
                    Thread.Sleep(50);
                }
                else
                {
                    break;
                }
            }
        }

        //Scroll to control
        public void ScrollToControl(By control)
        {
            var element = driver.FindElement(control);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void WaitForControl(By control, int milisecond)
        {
            double i = 0;
            while (i <= milisecond)
            {
                if (IsControlExist(control) == true)
                {
                    Thread.Sleep(300); //Make sure control is loaded on page
                    break;
                }
                else
                {
                    i = i + 200;
                    Thread.Sleep(200);
                }
            }
        }
        #endregion

        #region Common method of manage page

        //public void ActionOnTitle()
        //{
        //    SelectTitle();

        //}
        #endregion

        //Count Row on the table
        public int CountRow()
        {
            WaitForPageLoading(midterm);
            int rowNumber = driver.FindElements(row).Count();
            return rowNumber;
        }

        public bool IsIdAscending()
        {
            WaitForPageLoading(midterm);
            int n = CountRow();
            Console.WriteLine("n= " + n);
            int i = 1;
            while (i < n)
            {
                int value1 = Convert.ToInt32(driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[last()]")).Text);
                int value2 = Convert.ToInt32(driver.FindElement(By.XPath("//table/tbody/tr[" + (i + 1) + "]/td[last()]")).Text);
                if (value1 > value2)
                    return false;
                i = i + 1;
            }
            return true;
        }

        public bool IsIdDescending()
        {
            IsIdAscending();
            if (IsIdAscending() == true)
                return false;
            else return true;
        }

    }
}
