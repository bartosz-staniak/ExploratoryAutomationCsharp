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
            InitialPage initialPage = new InitialPage(webDriver, test);


            string buttonImageText = webDriver.FindElement(InitialPage.buttonImage).Text;
            Assert.AreEqual("Show this image", buttonImageText);


            webDriver.Quit();
        }

        [TestMethod]
        public void SecondTest()
        {
            InitialPageII initialPageII = new InitialPageII(webDriver, test);

            string buttonDivText = webDriver.FindElement(InitialPageII.button1).Text;
            Assert.AreEqual("Oh well, bring it back", buttonDivText);

            webDriver.Quit();
        }

        [TestMethod]
        public void DataListTest()
        {
            Datalist dataList = new Datalist(webDriver, test);

            Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed); // it's working

            webDriver.Quit();


        }
        
    }

}