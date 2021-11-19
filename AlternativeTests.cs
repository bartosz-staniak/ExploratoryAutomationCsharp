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
                AlertButtonClass.TriggerAlert(webDriver);
                System.Threading.Thread.Sleep(5000);
                Assert.IsTrue(AlertButtonClass.IsAlertPresent(webDriver));

                AlertButtonClass.VerifyAlertPresence(webDriver, "A test alert");
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
                AlertButtonClass.TriggerAlert(webDriver);
                System.Threading.Thread.Sleep(5000);
                Assert.IsTrue(AlertButtonClass.IsAlertPresent(webDriver));

                AlertButtonClass.AcceptAlert(webDriver);
                Assert.IsFalse(AlertButtonClass.IsAlertPresent(webDriver));
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
                PromptButtonClass.TriggerPrompt(webDriver);
                System.Threading.Thread.Sleep(5000);
                Assert.IsTrue(AlertButtonClass.IsAlertPresent(webDriver));

                AlertButtonClass.VerifyAlertPresence(webDriver, "A test prompt");
            }
            finally
            {
                webDriver.Quit();
            }
        }

        [TestMethod]
        public void VerifyPopUpPreseceTest()
        {
            try
            {
                PopUpButtonClass popUpButtonClass = new PopUpButtonClass(webDriver, "alertButton");
                popUpButtonClass.TriggerPopUp(webDriver);
                Assert.IsTrue(AlertButtonClass.IsAlertPresent(webDriver));

                AlertButtonClass.VerifyAlertPresence(webDriver, "A test prompt");
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