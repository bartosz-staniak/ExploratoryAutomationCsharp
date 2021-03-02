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
                string resultInWords = $"The hiedeous button is displayed for option 3: {result}";
                System.Console.WriteLine(resultInWords);

                using (StreamWriter sw = File.AppendText("report.txt"))
                {
                    sw.Write(resultInWords);
                }

                // Reporting to a file ends here

            }
            finally {
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
                
                // Reporting to a file starts here

                bool result = webDriver.FindElement(Datalist.hideousButton).Displayed;
                string resultInWords = $"The hiedeous button is displayed for option 13: {result}";
                System.Console.WriteLine(resultInWords);
                
                using (StreamWriter sw = File.AppendText("report.txt"))
                {
                    sw.Write(resultInWords);
                }

                // Reporting to a file ends here

            } finally
            {
                webDriver.Quit();
            }
            
        }
    }

}