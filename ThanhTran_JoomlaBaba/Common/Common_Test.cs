using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThanhTran_Joomla.Common;

namespace ThanhTran_Joomla.Pages
{
    public class Common_Test
    {

        #region Declare

        //Common variable
        public string username = "ThanhTran";
        public string password = "antbuddy";
        public string randomTitle = null;
        public string randomTitle2 = null;
        public string bannerTitle = null;
        public string categoryTitle = null;
        public string clientTitle = null;
        public string publishStatus = "Published";
        public string unPublishStatus = "Unpublished";
        public string archiveStatus = "Archived";
        public string author = "Thanh Tran";
        public string saveAndClose = "Save and Close";

        //Article variable
        public string categoryArticle = "Category 2";
        public string guestAccess = "Guest";
        public string contentEdit = " Edit rồi";
        public string content = "Trần Chí Thành";
        public string categoryEdit = "catagory 1";
        public string createArticleSuccessMessage = "Article successfully saved.";
        public string publishArticleSuccessMessage = "1 article published.";
        public string unPublishArticleSuccessMessage = "1 article unpublished.";
        public string archiveArticleSuccessMessage = "1 article archived.";
        public string checkInArticleSuccessMessage = "1 article successfully checked in.";
        public string trashArticleSuccessMessage = "1 article trashed.";
        public string featureArticleSuccessMessage = "1 article featured.";
        public string unFeatureArticleSuccessMessage = "1 article unfeatured.";

        //Contact variable
        public string categoryContact = "Uncategorised";
        public string categoryContactEdit = "Uncategorised";
        public string createContactSuccessMessage = "Contact successfully saved.";
        public string publishContactSuccessMessage = "1 contact successfully published.";
        public string unPublishContactSuccessMessage = "1 contact successfully unpublished.";
        public string archiveContactSuccessMessage = "1 contact successfully archived.";
        public string checkInContactSuccessMessage = "1 contact successfully checked in.";
        public string trashContactSuccessMessage = "1 contact successfully trashed.";
        public string featureContactSuccessMessage = "1 contact successfully featured.";
        public string unFeatureContactSuccessMessage = "1 contact successfully unfeatured.";


        //Client variable
        public string createClientSuccessMessage = "Client successfully saved.";
        public string publishClientSuccessMessage = "1 client successfully published.";
        public string unPublishClientSuccessMessage = "1 client successfully unpublished.";
        public string archiveClientSuccessMessage = "1 client successfully archived.";
        public string checkInClientSuccessMessage = "1 client successfully checked in.";
        public string trashClientSuccessMessage = "1 client successfully trashed.";
        public string featureClientSuccessMessage = "1 client successfully featured.";
        public string unFeatureClientSuccessMessage = "1 client successfully unfeatured.";
        public string contactName = "Thanh Tran";
        public string contactEmail = "thanhtran@htklabs.com";

        //Banner variable
        public string categoryBanner = "Uncategorised";
        public string categoryBannerEdit = "Uncategorised";
        public string createBannerSuccessMessage = "Banner successfully saved.";
        public string publishBannerSuccessMessage = "1 banner successfully published.";
        public string unPublishBannerSuccessMessage = "1 banner successfully unpublished.";
        public string archiveBannerSuccessMessage = "1 banner successfully archived.";
        public string checkInBannerSuccessMessage = "1 banner successfully checked in.";
        public string trashBannerSuccessMessage = "1 banner successfully trashed.";
        public string featureBannerSuccessMessage = "1 banner successfully featured.";
        public string unFeatureBannerSuccessMessage = "1 banner successfully unfeatured.";

        //Category variable
        public string parentCategory = "Uncategorised";
        public string parentCategoryEdit = "Uncategorised";
        public string createCategorySuccessMessage = "Category successfully saved.";
        public string publishCategorySuccessMessage = "1 category successfully published.";
        public string unPublishCategorySuccessMessage = "1 category successfully unpublished.";
        public string archiveCategorySuccessMessage = "1 category successfully archived.";
        public string checkInCategorySuccessMessage = "1 category successfully checked in.";
        public string trashCategorySuccessMessage = "1 category successfully trashed.";
        public string featureCategorySuccessMessage = "1 category successfully featured.";
        public string unFeatureCategorySuccessMessage = "1 category successfully unfeatured.";

        //Category variable

        public string createArticleCategorySuccessMessage = "Category successfully saved.";


        Common_Page commonPage = new Common_Page();

        #endregion

        #region Method

        public string RandomTitle()
        {
            string randomTitle;
            return randomTitle = DateTime.Now.ToString("ddMMyyhhmmss") + " ngày yêu em";
        }

        //Check isIDAscending
        public void CheckIsIdAscending(bool condition)
        {
            Assert.IsTrue(condition);
            //if (type == "Ascending")
            //    Assert.IsTrue(manageObjectPage.IsIDAscending());
            //if (type == "Descending")
            //    Assert.IsFalse(manageObjectPage.IsIDAscending());
        }

        //Check isIDDecending
        public void CheckIsIdDescending(bool condition)
        {
            Assert.IsTrue(condition);
        }
        //Check isID Decending
        //public void CheckIsIdDecending(bool condition)
        //{
        //    //if (type == "Ascending")
        //    //    Assert.IsTrue(manageObjectPage.IsIDAscending());
        //    //if (type == "Descending")
        //    //    Assert.IsFalse(manageObjectPage.IsIDAscending());
        //}

        //Check success notify display
        public void CheckMessage(string message,string getMessage)
        {
            //Check whether texts are same each other
            Assert.AreEqual(message,getMessage);
        }

        //Verify article exist on table
        public void CheckTitleExistOnTable(bool isTitleExistOntable)
        {

            Assert.IsTrue(isTitleExistOntable);
        }

        public void CheckTitleIsFeatured(bool isTitleFeatured)
        {
            Assert.IsTrue(isTitleFeatured);
        }

        public void CheckTitleIsUnfeatured(bool isTitleUnFeatured)
        {
            Assert.IsTrue(isTitleUnFeatured);
        }

        //Check number row display
        public void CheckNumberRowDisplay(bool doesNumberRowDisplayCorrectly)
        {
            Assert.IsTrue(doesNumberRowDisplayCorrectly);
        }

        //Check is help window displaying
        public void CheckWindowDisplaying(string title)
        {
            Assert.IsTrue(commonPage.IsPageDisplaying(title));
        }

        //Check is control change to red
        public void CheckIsControlChangeToRed(bool isControlChangeToRed)
        {
            Assert.IsTrue(isControlChangeToRed);
        }

        //Check is title current window display
        public void CheckIsCurrentWinDownDisplaying(bool isCurrentWindowDisplaying)
        {
            Assert.IsTrue(isCurrentWindowDisplaying);
        }

        //Check is window has the title exist
        public void CheckIsWindownHasTheTitleExist(bool isWindownHasTheTitleExist)
        {
            Assert.IsTrue(isWindownHasTheTitleExist);
        }
        #endregion
    }
}
