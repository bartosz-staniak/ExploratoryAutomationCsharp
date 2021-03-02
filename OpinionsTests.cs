// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

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
            try
            {
                Opinions multipleOpinionsTest = new Opinions(webDriver, 3, test);

                Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed);

            } finally {
                webDriver.Quit();
            }
            
        }

        [TestMethod]
        public void TestingTheNewOpinoinsConstructor13()
        {
            try
            {
                Opinions multipleOpinionsTest = new Opinions(webDriver, 13, test);

                Assert.IsTrue(webDriver.FindElement(Datalist.hideousButton).Displayed);
                
                bool result = webDriver.FindElement(Datalist.hideousButton).Displayed;
                string resultInWords = $"The hiedeous button is displayed: {result}";
                System.Console.WriteLine(resultInWords);

            } finally
            {
                webDriver.Quit();
            }
            
        }
    }

}