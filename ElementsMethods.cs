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
            webDriver = driver;
        }
        
        public InitialPage(IWebDriver driver, string any)
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

        }
        
        public InitialPageII(IWebDriver driver, string any) : base(driver, any)
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
        public Datalist(IWebDriver driver) : base (driver)
        {

        }

        
        public Datalist(IWebDriver driver, string any) : base(driver, any)
        {
            this.navigateDataList();
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

    public class Opinions : Datalist
    {
        public Opinions(IWebDriver driver) : base(driver)
        {

        }
        
        public Opinions(IWebDriver driver, string any) : base(driver, any)
        {
            navigateDataList();
        }

        public Opinions(IWebDriver driver, int option, string any) : base(driver)
        {
            if (option == 1)
            {
                this.navigateDataList(opinionOne);
            }
            else if (option == 3) {
                this.navigateDataList(opinionThree);
            }
            else
                this.navigateDataList(opinionTwo);
        }

        public static By opinionThree = By.XPath("//*[@id='opinions']/option[3]");
        public static By opinionFour = By.XPath("//*[@id='opinions']/option[4]");
        public static By opinionFive = By.XPath("//*[@id='opinions']/option[5]");
        public static By opinionSix = By.XPath("//*[@id='opinions']/option[6]");
        public static By opinionSeven = By.XPath("//*[@id='opinions']/option[7]");
        public static By opinionEight = By.XPath("//*[@id='opinions']/option[8]");
        public static By opinionNine = By.XPath("//*[@id='opinions']/option[9]");
        public static By opinionTen = By.XPath("//*[@id='opinions']/option[10]");
        public static By opinionEleven = By.XPath("//*[@id='opinions']/option[11]");
        public static By opinionTwelve = By.XPath("//*[@id='opinions']/option[12]");
        public static By opinionThirteen = By.XPath("//*[@id='opinions']/option[13]");
    }

}