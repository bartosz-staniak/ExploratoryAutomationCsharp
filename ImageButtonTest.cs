// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PageObjectPatternDemo
{

    [TestClass]
    public class ImageButtonTest : Configuration
    {
        // string test = ("test");

        [TestMethod]
        public void FirstTest()
        {

            try
            {
                InitialPage initialPage = new InitialPage(webDriver, test);

                string buttonImageText = webDriver.FindElement(InitialPage.buttonImage).Text;
                Assert.AreEqual("Show this image", buttonImageText);
            } finally {
                webDriver.Quit();
            }

        }

        [TestMethod]
        public void SecondTest()
        {

            try
            {
                InitialPageII initialPageII = new InitialPageII(webDriver, test);

                string buttonDivText = webDriver.FindElement(InitialPageII.button1).Text;
                Assert.AreEqual("Oh well, bring it back", buttonDivText);
            } finally {
                webDriver.Quit();
            }

        }

        [TestMethod]
        public void DataListTest()
        {
            try
            {
                Datalist dataList = new Datalist(webDriver, test);

                Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed); // it's working
            } finally {
                webDriver.Quit();
            }
        
        }
        
    }

    [TestClass]
    public class AlternativeTests : Configuration
    {
        [TestMethod] // this test method can be extended as it's not meant to be an end-to-end method, as long as all methods do not call driver's .quit method
        public void alternativeInitialTest()
        {
            try
            {
                InitialPage initialPage = new InitialPage(webDriver);
                initialPage.hideImageDisableQuit(webDriver, true);
                initialPage.hideImageCustomAssert();
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialPage.buttonImage).Text);

                initialPage.hideImageBoolQuitAssert(webDriver, true, false);
                initialPage.hideImageBoolQuitAssert(webDriver, true, true);
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialPage.buttonImage).Text);
                initialPage.hideImageBoolQuitAssert(webDriver, false, false);
            } finally {
                webDriver.Quit();
            }
            
        }
    }

}