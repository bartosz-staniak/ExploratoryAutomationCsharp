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
                InitialClass initialPage = new InitialClass(webDriver, test);

                string buttonImageText = webDriver.FindElement(InitialClass.buttonImage).Text;
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
                InitialClassII initialPageII = new InitialClassII(webDriver, test);

                string buttonDivText = webDriver.FindElement(InitialClassII.hideousButton).Text;
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
                System.Threading.Thread.Sleep(5000);
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
                InitialClass initialPage = new InitialClass(webDriver);
                initialPage.hideImageDisableQuit(webDriver, true);
                initialPage.hideImageCustomAssert();
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);

                initialPage.hideImageBoolQuitAssert(webDriver, true, false);
                initialPage.hideImageBoolQuitAssert(webDriver, true, true);
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);
                initialPage.hideImageBoolQuitAssert(webDriver, false, false);
            } finally {
                webDriver.Quit();
            }
            
        }
    }

}