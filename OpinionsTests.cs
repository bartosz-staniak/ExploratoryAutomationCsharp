// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class OpinionsTests : ImageButtonTest
    {
        // IWebDriver webDriver; // trying to find out if this solves the inaccessibility due to protection level issue

        /*
        public OpinionsTests() : base()
        {
            // this is sufficient for using all inherited test methods without changes
        }
        */

        [TestMethod]
        public void AnotherAttempt()
        {
            InitialPage initialPage = new InitialPage(webDriver);


            string buttonImageText = webDriver.FindElement(InitialPage.buttonImage).Text;
            Assert.AreEqual("Show this image", buttonImageText);


            webDriver.Quit();
        }
    }

}