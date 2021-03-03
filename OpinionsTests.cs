// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;

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

                // Reporting to a file starts here

                bool result = webDriver.FindElement(Datalist.hideousButton).Displayed;
                string resultInWords = $"For option 3 the button is displayed. Expected: False, Actual: {result}";
                System.Console.WriteLine(resultInWords);

                using (StreamWriter sw = File.AppendText("report.txt"))
                {
                    sw.Write(Environment.NewLine + resultInWords);
                }

                // Reporting to a file ends here

            }
            finally {
                webDriver.Quit();
            }
            
        }

        [TestMethod]
        public void AnUglyIdeaInTest()
        {
            PageObjectPatternDemo.Opinions.letMeSeeIfThisUglyIdeaWorks(webDriver, false); // remember to removed static keywords from IWebDriver and this ugly method in ElementsMethods file
        }
        
        [TestMethod]
        public void TestingTheNewOpinoinsConstructor13()
        {
            try
            {
                Opinions multipleOpinionsTest = new Opinions(webDriver, 13, test);

                Assert.IsTrue(webDriver.FindElement(Datalist.hideousButton).Displayed);
                
                // Reporting to a file starts here

                bool result = webDriver.FindElement(Datalist.hideousButton).Displayed;
                string resultInWords = $"For Option 13 the button is displayed. Expected: True, Actual: {result}";
                System.Console.WriteLine(resultInWords);
                
                using (StreamWriter sw = File.AppendText("report.txt"))
                {
                    sw.Write(Environment.NewLine + resultInWords);
                }

                // Reporting to a file ends here

            } finally
            {
                webDriver.Quit();
            }
            
        }
    }

    [TestClass]
    public class ReportingTests : OpinionsTests
    {
        [TestMethod]
        public void TestingPresenceOfTextarea()
        {
            try
            {
                // TestingTheNewOpinoinsConstructor13(); // this one is failing, most probably due to driver.Quit() method

                Reporting reporting = new Reporting(webDriver);
                Assert.IsTrue(webDriver.FindElement(Reporting.textArea).Displayed);
                string nullOrNotNull = null;
                nullOrNotNull = webDriver.FindElement(Reporting.textArea).GetAttribute("value");
                Assert.AreNotEqual("", nullOrNotNull); // Doesn't work as I thought it would

            } finally {
                System.Threading.Thread.Sleep(5000);
                webDriver.Quit();
            }
            
        }
    }

}