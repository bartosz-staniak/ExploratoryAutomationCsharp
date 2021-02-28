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
        public void troubleshootingTest()
        {
            Opinions basicTest = new Opinions(webDriver, test);
        }

        [TestMethod]
        public void TestingTheNewOpinoinsConstructor()
        {
            Opinions multipleOpinionsTest = new Opinions(webDriver, 2, test);
        }
    }

}