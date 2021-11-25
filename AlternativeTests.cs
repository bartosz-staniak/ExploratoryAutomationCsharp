// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class AlternativeTests : Configuration
    {
        [TestMethod] // this test method can be extended as it's not meant to be an end-to-end method, as long as all methods do not call driver's .quit method
        public void alternativeInitialTest()
        {
            try
            {
                InitialClass initialPage = new InitialClass(webDriver);
                initialPage.hideImageDisableQuit(webDriver, true);
                initialPage.hideImageCustomAssert();
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);

                initialPage.HideImageBoolQuitAssert(webDriver, true, false);
                initialPage.HideImageBoolQuitAssert(webDriver, true, true);
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);
                initialPage.HideImageBoolQuitAssert(webDriver, false, false);
            } finally {
                webDriver.Quit();
            }
            
        }
    }

    [TestClass]
    public class CustomTests : Configuration
    {
        [TestMethod]
        public void customMethod()
        {
            try
            {
                Datalist.NavigateDataListDriver(webDriver); // add sleep and another method to see if this approach works
                System.Threading.Thread.Sleep(5000);
            } finally {
                webDriver.Quit();
            }
        }
        [TestMethod]
        public void getRecordTest()
        {
            try
            {
                API_elements api_Elements = new API_elements(webDriver);
                api_Elements.getRecordFromDb(1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(webDriver.FindElement(API_elements.readRecordParagraph), "Id:")); //returned failed result with "Ib:"
                Assert.IsTrue(webDriver.FindElement(API_elements.readRecordParagraph).Text.Contains("Id:"));
            }
            finally
            {
                webDriver.Quit();
            }

        }

        [TestMethod]
        public void getNoRecordTest()
        {
            try
            {
                API_elements api_Elements = new API_elements(webDriver);
                api_Elements.getRecordFromDb(0);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(webDriver.FindElement(API_elements.readRecordParagraph), "Request failed")); //returned failed result with "Ib:"
                Assert.IsTrue(webDriver.FindElement(API_elements.readRecordParagraph).Text.Contains("Request failed"));
            }
            finally
            {
                webDriver.Quit();
            }

        }

        [TestMethod]
        public void NegativeRedundantElementsPresenceTest()
        {
            try
            {
                RedundantElements redundantElements = new RedundantElements(webDriver);
                foreach (IWebElement redundant in RedundantElements.redundants)
                {
                    Assert.IsFalse(redundant.Displayed);
                }

            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void VerifyAlertPresenceTest()//wip
        {
            try
            {
                PopUpMethodsClass popUpMethodsClass = new PopUpMethodsClass(webDriver, "alertButton");
                popUpMethodsClass.TriggerPopUp(webDriver);
                System.Threading.Thread.Sleep(5000);
                Assert.IsTrue(PopUpMethodsClass.IsPopUpPresent(webDriver));

                PopUpMethodsClass.VerifyPopUpPresence(webDriver, "A test alert");
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void AcceptAlertTest()//wip
        {
            try
            {
                PopUpMethodsClass popUpMethodsClass = new PopUpMethodsClass(webDriver, "alertButton"); //more flexible yet cannot disconnect the user from the implementation this way
                popUpMethodsClass.TriggerPopUp(webDriver);

                Assert.IsTrue(PopUpMethodsClass.IsPopUpPresent(webDriver));

                PopUpMethodsClass.AcceptPopUp(webDriver);
                Assert.IsFalse(PopUpMethodsClass.IsPopUpPresent(webDriver));
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void VerifyPromptPresenceTest()
        {
            try
            {
                PopUpMethodsClass popUpMethodsClass = new PopUpMethodsClass(webDriver, "promptButton");
                popUpMethodsClass.TriggerPopUp(webDriver);

                Assert.IsTrue(PopUpMethodsClass.IsPopUpPresent(webDriver));

                PopUpMethodsClass.VerifyPopUpPresence(webDriver, "A test prompt");
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void VerifyPopUpPresenceTest()
        {
            try
            {
                PopUpMethodsClass popUpMethodsClass = new PopUpMethodsClass(webDriver, "alertButton");
                popUpMethodsClass.TriggerPopUp(webDriver);
                Assert.IsTrue(PopUpMethodsClass.IsPopUpPresent(webDriver));

                PopUpMethodsClass.VerifyPopUpPresence(webDriver, "A test alert");
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod] //wip
        public void VerifyAlertPresenceAfterAcceptingPrompt()
        {
            try
            {
                string testedInputString = "A test input string";
                PopUpMethodsClass popUpMethodsClass = new PopUpMethodsClass(webDriver, "promptButton");
                popUpMethodsClass.TriggerPopUp(webDriver);
                PopUpMethodsClass.VerifyPopUpSendKeysAccept(webDriver, "A test prompt", "A test input string");
                System.Threading.Thread.Sleep(5000);
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void WipElementsPresenceTest()
        {
            try
            {
                WipElements wipElements = new WipElements(webDriver);
                foreach(IWebElement wip in WipElements.wips)
                {
                    Assert.IsTrue(wip.Displayed);
                }
            }
            finally
            {
                webDriver.Quit();
            }
        }

    }
}