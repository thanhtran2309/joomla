using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Pages;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla
{
    [TestClass]
    public class SortContact : Common_Test
    {
        #region Declare
        Common_Page commonPage;
        Login_Page loginPage;
        ControlPanel_Page controlPanelPage;
        ContactManage_Page contactManagePage;

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            contactManagePage = new ContactManage_Page();

            commonPage = new Common_Page();
            commonPage.NavigateJoomla();

            loginPage = new Login_Page();
            loginPage.Login(username, password);

            controlPanelPage = new ControlPanel_Page();
            controlPanelPage.OpenContactPage();
        }

        [TestMethod]
        public void TC11_Verify_user_can_sort_the_contact_table_by_ID_column()
        {
            contactManagePage.ClickIDbutton();
            bool isIdAscending = contactManagePage.IsIdAscending();
            CheckIsIdAscending(isIdAscending);

            contactManagePage.ClickIDbutton();
            bool isIdDescending = contactManagePage.IsIdDescending();
            CheckIsIdDescending(isIdDescending);
        }

        [TestMethod]
        public void TC12_Verify_user_can_paging_the_contact_using_the_paging_control()
        {
            contactManagePage.SelectDisplayRow("5");

            bool doesNumberRowDisplayCorrectly = contactManagePage.IsRowDisplayEqualtoInput();
            CheckNumberRowDisplay(doesNumberRowDisplayCorrectly);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Console.WriteLine("Run TestCleanup");
            commonPage.QuitBrowser();
        }

    }
}
