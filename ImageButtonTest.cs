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
            


            webDriver.Quit();
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

}