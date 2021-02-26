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
            this.navigateDataList(opinionOne);
        }

        public static By dataList = By.Id("dataList");
        public static By opinions = By.Id("opinions");
        public static By opinionOne = By.XPath("//*[@id='opinions']/option[1]");
        public static By opinionTwo = By.XPath("//*[@id='opinions']/option[2]");
        public static By hideousButton = By.XPath("/html/body/button");

        public void navigateDataList()
        {
            string opinionOneToString = webDriver.FindElement(opinionOne).GetAttribute("value");
            webDriver.FindElement(dataList).SendKeys(opinionOneToString);
            Actions action = new Actions(webDriver);
            action.MoveToElement(webDriver.FindElement(dataList)).MoveByOffset(0, 100).Click().Build().Perform(); // it's working, the button disappeared
        }

        public void navigateDataList(By opinion)
        {
            string option = webDriver.FindElement(opinion).GetAttribute("value");
            webDriver.FindElement(dataList).SendKeys(option);
            Actions action = new Actions(webDriver);
            action.MoveToElement(webDriver.FindElement(dataList)).MoveByOffset(0, 100).Click().Build().Perform();
        }
    }

    public class Datalist_ShowButton : Datalist
    {
        public Datalist_ShowButton(IWebDriver driver) : base(driver)
        {

        }
    }

}