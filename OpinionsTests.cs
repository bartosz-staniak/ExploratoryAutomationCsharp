// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class OpinionsTests : ImageButtonTest
    {
        IWebDriver webDriver; // trying to find out if this solves the inaccessibility due to protection level issue

        /*
        public OpinionsTests() : base()
        {
            // this is sufficient for using all inherited test methods without changes
        }
        */

        public OpinionsTests() : base()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            webDriver = new ChromeDriver(@"C:\ChromeDriver", chromeOptions);
            webDriver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
            webDriver.Manage().Window.Maximize();
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(50));
        }

        [TestMethod]
        public void DataListTestTroubleshooting()  // doesn't work due to: "Object reference not set to an instance of an object."
        {
            Datalist dataListTroubleshooting = new Datalist(webDriver);

            Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed); // it's working

            webDriver.Quit();


        }

    }

}