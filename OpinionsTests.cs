﻿// using MbUnit.Framework;
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
                
                // Reporting to a file starts here

                bool result = webDriver.FindElement(Datalist.hideousButton).Displayed;
                string resultInWords = $"The hiedeous button is displayed: {result}";
                System.Console.WriteLine(resultInWords);

                using (var fileStream = File.Create("report.txt"))
                {
                    var Bytes = new UTF8Encoding(true).GetBytes(resultInWords);
                    fileStream.Write(Bytes, 0, Bytes.Length);
                }

                // Reporting to a file ends here

            } finally
            {
                webDriver.Quit();
            }
            
        }
    }

}