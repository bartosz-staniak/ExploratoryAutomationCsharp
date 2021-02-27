// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class OpinionsTests : ImageButtonTest
    {
        IWebDriver webDriver; // trying to find out if this solves the inaccessibility due to protection level issue

        public OpinionsTests() : base()
        {

        }

        [TestMethod]
        public void DataListTestOverwrite()  // doesn't work due to: "Object reference not set to an instance of an object."
        {
            Datalist dataList = new Datalist(webDriver);

            Assert.IsFalse(webDriver.FindElement(Datalist.hideousButton).Displayed); // it's working

            webDriver.Quit();


        }

    }

}