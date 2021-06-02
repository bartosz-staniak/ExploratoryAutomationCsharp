// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PageObjectPatternDemo
{

    [TestClass]
    public class ClickBtnToHideImageTest : Configuration
    {
        // string test = ("test");

        [TestMethod]
        public void HideImageTest()
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
        public void HidePageContents()
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
                Wait.Until(ExpectedConditions.ElementToBeClickable(webDriver.FindElement(Datalist.hideousButton));
                Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed); // it's working
            } finally {
                webDriver.Quit();
            }
        
        }
        
    }

}