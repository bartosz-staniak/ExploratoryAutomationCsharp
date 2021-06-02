// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class Configuration
    {
        public IWebDriver webDriver;
        public static WebDriverWait Wait;


        public Configuration()
        {


            Wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 5));

            try
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("disable-infobars");
                webDriver = new ChromeDriver(@"C:\ChromeDriver", chromeOptions);
                webDriver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
                webDriver.Manage().Window.Maximize();
                
                createReportFile(); // part of the attempt to create the report file for the global use
            } catch {
                webDriver.Quit(); // if tests fail here then check driver version
            }
            
        }

        public string test = ("test");


        // an attempt to create a file gloabally
        public void createReportFile()
        {
            if (!File.Exists("report.txt"))
            {
                using var fileStream = File.Create("report.txt");
            }
            

        }

    }

}