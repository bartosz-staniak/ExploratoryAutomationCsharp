// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class OpinionsTests : Configuration
    {
        /*
        public OpinionsTests() : base() // works without this constructor if no other is used
        {
            // this is sufficient for using all inherited test methods without changes
        }
        */

        [TestMethod]
        public void TestingTheNewOpinoinsConstructor()
        {
            Opinions multipleOpinionsTest = new Opinions(webDriver, 3, test);

            Assert.IsTrue(webDriver.FindElement(Datalist.hideousButton).Displayed);

            webDriver.Quit();
        }

        [TestMethod]
        public void TestingTheNewOpinoinsConstructor13()
        {
            Opinions multipleOpinionsTest = new Opinions(webDriver, 13, test);

            Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed);

            webDriver.Quit();
        }
    }

}