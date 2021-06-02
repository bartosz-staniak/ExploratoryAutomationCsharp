﻿// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PageObjectPatternDemo
{
    [TestClass]
    public class AlternativeTests : Configuration
    {
        [TestMethod] // this test method can be extended as it's not meant to be an end-to-end method, as long as all methods do not call driver's .quit method
        public void alternativeInitialTest()
        {
            try
            {
                InitialClass initialPage = new InitialClass(webDriver);
                initialPage.hideImageDisableQuit(webDriver, true);
                initialPage.hideImageCustomAssert();
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);

                initialPage.HideImageBoolQuitAssert(webDriver, true, false);
                initialPage.HideImageBoolQuitAssert(webDriver, true, true);
                Assert.AreEqual("Hide this image", webDriver.FindElement(InitialClass.buttonImage).Text);
                initialPage.HideImageBoolQuitAssert(webDriver, false, false);
            } finally {
                webDriver.Quit();
            }
            
        }
    }

    [TestClass]
    public class CustomTests : Configuration
    {
        [TestMethod]
        public void customMethod()
        {
            try
            {
                Datalist.NavigateDataListDriver(webDriver); // add sleep and another mehotd to see if this approach works
                System.Threading.Thread.Sleep(5000);
            } finally {
                webDriver.Quit();
            }
        }

    }
}