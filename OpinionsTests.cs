// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class OpinionsTests : Configuration
    {
        /*
        public OpinionsTests() : base()
        {
            // this is sufficient for using all inherited test methods without changes
        }
        */

        [TestMethod]
        public void AnotherAttempt()
        {
            Opinions opionstest = new Opinions(webDriver);


            string buttonImageText = webDriver.FindElement(InitialPage.buttonImage).Text;
            Assert.AreEqual("Show this image", buttonImageText);


            webDriver.Quit();
        }
    }

}