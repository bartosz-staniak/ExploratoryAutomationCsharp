// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class ImmageButtonTest
    {
        IJavaScriptExecutor buttonexec;

        IWebDriver webDriver;

        public ImmageButtonTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            webDriver = new ChromeDriver(@"C:\ChromeDriver", chromeOptions);
            webDriver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            webDriver.Manage().Window.Maximize();
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
        }

        [TestMethod]
        public void FirstTest()
        {
            InitialPage initialPage = new InitialPage(webDriver);


            string buttonImageText = webDriver.FindElement(InitialPage.buttonImage).Text;
            Assert.AreEqual("Show this image", buttonImageText);


            webDriver.Quit();
        }

        [TestMethod]
        public void SecondTest()
        {
            InitialPageII initialPageII = new InitialPageII(webDriver);

            string buttonDivText = webDriver.FindElement(InitialPageII.button1).Text;
            Assert.AreEqual("Oh well, bring it back", buttonDivText);

            webDriver.Quit();
        }

        [TestMethod]
        public void DataListTest()
        {
            Datalist dataList = new Datalist(webDriver);

            System.Threading.Thread.Sleep(5000); // I know, I know

            Assert.IsTrue(webDriver.FindElement(Datalist.hideousButton).Displayed);

            webDriver.Quit();


        }
        
    }

}