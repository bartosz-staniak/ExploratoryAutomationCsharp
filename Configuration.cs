// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class Configuration
    {
        public IWebDriver webDriver;


        public Configuration()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            webDriver = new ChromeDriver(@"C:\ChromeDriver", chromeOptions);
            webDriver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            webDriver.Manage().Window.Maximize();
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
        }

        public string test = ("test");

    }

}