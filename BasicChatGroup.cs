using NUnit.Framework;
using Antbuddy_Auto.Common;
using Antbuddy_Auto.Pages;
using System;
using Antbuddy_Auto.Pages.Chat_Pages;
using System.Threading;

namespace Antbuddy_Auto.TestCases.BasicFeatureChat_TC
{
    [TestFixture]
    class BasicChatGroup : General_TCs
    {
        [OneTimeSetUp]
        public void TestClassSetUp()
        {
            OneTimeSetUpReport();
            general = new General();
            loginPage = new Login_Page();
            groupChat = new GroupChat();
            lauchpadPage = new Lauchpad_Page();
            groupChat = new GroupChat();

            //Login
            general.OpenBrowserwithURL("", UrlOfAntChat);
            loginPage.LoginAntBuddy(ownerEmail, ownerPassword);
            lauchpadPage.SelectNameCompany(companyName);

            //Create group
            general.OpenLeftMenu(groupSection);
            groupChat.ClickAddGroup();
            groupNameRandom = RandomValue(4);
            groupChat.CreateGroup(groupNameRandom, emptyGroupTopic, "", "Create");
            groupChat.InviteMember(user2Username, "Invite");
        }

        [SetUp]
        public void SetupTestMethod()
        {
            StartTest();

            //Set variable
            randomMessage = RandomValue(4);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_001_Verify_that_user_can_chat_characters_in_group()
        {
            //Send message
            groupChat.SendMessage(randomMessage);

            //Check message display
            bool isMessageDisplay = general.IsMessageDisplayed(randomMessage);
            VerifyMessageDisplayed(isMessageDisplay);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_002A_Verify_that_user_can_mention_chat_in_group_successfully()
        {
            //Mention message
            groupChat.MentionMessage(ownerUsername,randomMessage);

            //Check display mention popup when click on username
            bool isMentionDisplayedCorrectly = general.IsMentionDisplayedCorrectly("@" + ownerFullname);
            VerifyUserInfoPopupDisplayed(isMentionDisplayedCorrectly);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_002B_Verify_that_when_user_mention_All_that_display_in_Me_tab()
        {
            //Mention @All
            groupChat.MentionMessage("All", randomMessage);

            //Check @All display in Me tab
            general.OpenTabInRightMenu("Me");
            VerifyResultIsTrue(general.IsMentionMessageDisplayInMe("@All", randomMessage));
        }

        [Test]
        public void TC_AB_CHAT_GROUP_003_Verify_that_user_can_send_highlight_message_in_group_chat_successfully()
        {
            //Send highlight message
            string highlightMessageSend = "`" + randomMessage + "`";
            groupChat.SendMessage(highlightMessageSend);

            //Check display highlight message
            bool isHighLightDisplayedCorrectly = general.IsMessageHighLight(randomMessage);
            VerifyMessageHighlight(isHighLightDisplayedCorrectly);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_004_Verify_that_user_can_send_code_block_message_in_group_chat_successfully()
        {
            //Send code block message
            string codeBlockMessageSend = "```" + randomMessage + "```";
            groupChat.SendMessage(codeBlockMessageSend);

            bool isCodeBlockDisplayedCorrectly = general.IsMessageCodeBlock(randomMessage);
            VerifyResultIsTrue(isCodeBlockDisplayedCorrectly);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_005_Verify_that_user_can_buzz_message_in_quick_menu_successfully()
        {
            //Send message
            groupChat.SendMessage(randomMessage);

            //Check buzz message
            groupChat.MessageOptionInGroup("Buzz",randomMessage);
            bool isBuzzNotifyDisplay = general.IsBuzzNotifyDisplay();
            VerifyBuzzNotifyDisplay(isBuzzNotifyDisplay);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_006_Verify_that_user_can_quote_message_in_quick_menu_successfully()
        {
            string randomMessage1 = RandomValue(4);
            string randomMessage2 = RandomValue(4);

            groupChat.SendMessage(randomMessage1);
            groupChat.MessageOptionInGroup("Quote", randomMessage1);
            groupChat.SendMessage(randomMessage2);

            bool isQuoteNotifyDisplay = general.IsMessageQuoted(randomMessage1, randomMessage2);
            VerifyQuoteMessageDisplay(isQuoteNotifyDisplay);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_007_Verify_that_user_can_pin_message_in_quick_menu_successfully()
        {
            //Send message
            groupChat.SendMessage(randomMessage);

            //Check pin message
            groupChat.PinMessage(randomMessage);
            general.OpenTabInRightMenu("Info");
            bool isPinMessageCorrect = groupChat.IsPinMessageCorrect(randomMessage);
            VerifyPinMessageDisplay(isPinMessageCorrect);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_011_Verify_that_user_can_bookmark_message_in_quick_menu_successfully()
        {
            //Send message
            groupChat.SendMessage(randomMessage);

            groupChat.MessageOptions("Bookmark", randomMessage);
            general.OpenSaveTab();

            bool isMessageExistInSave = general.IsMessageBookmarked(randomMessage);
            VerifyBookmarkMessageDisplayInSave(isMessageExistInSave);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_012_Verify_that_admin_can_delete_message_in_quick_menu_successfully_()
        {
            //Send message
            groupChat.SendMessage(randomMessage);

            general.DeleteMessage(randomMessage);

            bool isMessageDeleted = general.IsMessageDeleted(randomMessage);
            VerifyMessageIsDeleted(isMessageDeleted);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_013_Verify_that_user_can_edit_message_in_quick_menu_successfully()
        {
            //Send message
            string messageEdit = randomMessage + " edit";

            groupChat.SendMessageToGroup(randomMessage);
            general.EditMessage(randomMessage, messageEdit);

            bool isMessageDisplayed = general.IsMessageDisplayed(messageEdit);
            VerifyMessageDisplayed(isMessageDisplayed);
        }

        [Test]
        public void TC_AB_CHAT_GROUP_015_Verify_that_user_can_send_emoji_in_chat_successfully()
        {
            groupChat.SendEmoji(emoji);

            bool isMessageDisplayed = general.IsMessageDisplayed(emoji);
            VerifyMessageDisplayed(isMessageDisplayed);

        }

        [Test]
        public void TC_AB_CHAT_GROUP_021_Verify_that_user_can_send_bonus_user_successfully()
        {
            general.OpenBonusTab();
            int getCurrentPoint = general.GetCurrentBonusPoint();

            if (getCurrentPoint != 0)
            {
                groupChat.BonusInGroup("05", user2Fullname, bonusContent, "Send");

                VerifyResultIsTrue(general.IsBonusSuccessfull(user2Username, bonusContent, "05"));

                general.ClickSendMore();

                VerifyResultIsTrue(general.IsCurrentPointEqualTo(getCurrentPoint - 5));
            }
        }
        [Test]
        public void TC_AB_CHAT_GROUP_022_Verify_that_user_can_cancel_send_bonus_user_successfully()
        {
            general.OpenBonusTab();

            int getCurrentPoint = general.GetCurrentBonusPoint();

            if (getCurrentPoint != 0)
            {
                groupChat.BonusInGroup("05", user2Fullname, bonusContent, "Cancel");
                VerifyResultIsTrue(general.IsBonusTabDisplay());
            }
        }
        [TearDown]
        public void MethodTearDown() {
            CreateReportResult();
        }
        [OneTimeTearDown]
        public void TestClassTearDown()
        {
            general.CloseBrowser();
            OneTimeTearDownReport();
        }
    }
}
