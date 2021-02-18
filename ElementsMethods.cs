// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectPatternDemo
{
    [TestClass]

    public class InitialPage
    {
        public IWebDriver webDriver; // there wasn't "public"
        public InitialPage(IWebDriver driver)
        {
            webDriver = driver; // there was "this."webDriver
            this.hideImage();
            this.WaitTenSec();
        }

        public static By buttonImage = By.Id("buttonImage");

        public void hideImage()
        {
            webDriver.FindElement(InitialPage.buttonImage).Click();
            WaitTenSec();
        }


        public void WaitTenSec()
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

    }


    public class InitialPageII : InitialPage
    {
        public InitialPageII(IWebDriver driver) : base(driver)
        {
            this.hideMainDiv();
            this.WaitTenSec();
        }

        public static By button1 = By.Id("button1");

        public void hideMainDiv()
        {
            webDriver.FindElement(InitialPageII.button1).Click();
            WaitTenSec();
        }

    }

    public class Datalist : InitialPage
    {
        public Datalist(IWebDriver driver) : base(driver)
        {
            this.navigateDataList();
        }

        public static By dataList = By.Id("dataList");
        public static By opinions = By.Id("opinions");

        public void navigateDataList()
        {
            // webDriver.FindElement(dataList).Click();

            // Actions action = new Actions(webDriver);
            // action.MoveToElement(webDriver.FindElement(dataList)).Perform();
            /*
            System.Threading.Thread.Sleep(5000);
            action.MoveToElement(webDriver.FindElement(dataList))
                .Click().Build().Perform();
            System.Threading.Thread.Sleep(1000);
            action.MoveByOffset(0, 150).Build().Perform(); // 10px of either direction X offset didn't help
            System.Threading.Thread.Sleep(1000);
            action.Click().Build().Perform();
            System.Threading.Thread.Sleep(1000);
            action.Click().Build().Perform();
            System.Threading.Thread.Sleep(5000);
            action.Click().Build().Perform();
            System.Threading.Thread.Sleep(5000);
            */

            // Looks like using the same action object might be just adding
            // actions to one set of them???
            // Added action2 object to see if there is a difference

            /*
            Actions action2 = new Actions(webDriver);
            action2.Click().Build().Perform();
            System.Threading.Thread.Sleep(5000);
            */

            // Added action3 object to explore this issue further
            /*
            Actions action3 = new Actions(webDriver);
            action3.MoveToElement(webDriver.FindElement(dataList))
                .Click().MoveByOffset(0,150).Build().Perform();
            */
            
            System.Threading.Thread.Sleep(5000);

            // Added action 4 to use the contextClick to see where
            // the script clicks exactly
            
            Actions action4 = new Actions(webDriver);
            action4.MoveToElement(webDriver.FindElement(dataList))
                .Click().MoveByOffset(0,150)
                .ContextClick().Build().Perform();

            System.Threading.Thread.Sleep(5000);

            Actions action5 = new Actions(webDriver);
            action5.MoveToElement(webDriver.FindElement(dataList))
                .Click().ClickAndHold().MoveByOffset(0, 150)
                .Release()
                .Click().Build().Perform();

            System.Threading.Thread.Sleep(5000);

            /*
            var list = webDriver.FindElement(opinions);
            var selectElement = new SelectElement(list);
            selectElement.SelectByText("okay.");
            */
        }
    }

}