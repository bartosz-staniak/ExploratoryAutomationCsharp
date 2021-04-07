// using MbUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectPatternDemo
{

    public class InitialClass
    {
        public static IWebDriver webDriver; // there wasn't "public"

        public InitialClass()
        {

        }
        
        public InitialClass(IWebDriver driver)
        {
            webDriver = driver;
        }
        
        public InitialClass(IWebDriver driver, string any)
        {
            webDriver = driver; // there was "this."webDriver
            this.hideImage();
            this.WaitTenSec();
        }

        public static By buttonImage = By.Id("buttonImage");
        public static By hideousButton = By.Id("hideous_btn");

        public void hideImage()
        {
            webDriver.FindElement(InitialClass.buttonImage).Click();
            WaitTenSec();
        }

        public void hideImageCustomAssert()
        {
            webDriver.FindElement(InitialClass.buttonImage).Click();
            WaitTenSec();
        }

        public void hideImageDisableQuit(IWebDriver driver, bool disableQuit)
        {
            try
            {
                webDriver.FindElement(InitialClass.buttonImage).Click();
                WaitTenSec();
                Assert.AreEqual("Show this image", driver.FindElement(InitialClass.buttonImage).Text);
            } finally {
                if (!disableQuit)
                webDriver.Quit();
            }
            
        }

        public void hideImageBoolQuitAssert(IWebDriver driver, bool disableQuit, bool disableAssert)
        {
            try
            {
                webDriver.FindElement(InitialClass.buttonImage).Click();
                WaitTenSec();

                if (!disableAssert)
                Assert.AreEqual("Show this image", driver.FindElement(InitialClass.buttonImage).Text);
            }
            finally
            {
                if (!disableQuit)
                    webDriver.Quit();
            }
        }


        public void WaitTenSec()
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

    }


    public class InitialClassII : InitialClass
    {
        public InitialClassII(IWebDriver driver) : base(driver)
        {

        }
        
        public InitialClassII(IWebDriver driver, string any) : base(driver, any)
        {
            this.hideMainDiv();
            this.WaitTenSec();
        }

        public void hideMainDiv()
        {
            webDriver.FindElement(InitialClassII.hideousButton).Click();
            WaitTenSec();
        }

    }

    public class Datalist : InitialClass
    {
        public Datalist(IWebDriver driver) : base (driver)
        {

        }

        
        public Datalist(IWebDriver driver, string any) : base(driver, any)
        {
            NavigateDataList();
        }

        public static By dataList = By.Id("dataList");
        public static By opinions = By.Id("opinions");
        public static By opinionOne = By.XPath("//*[@id='opinions']/option[1]");
        public static By opinionTwo = By.XPath("//*[@id='opinions']/option[2]");
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
        // public static By hideousButton = By.XPath("/html/body/div/button[2]");

        public void NavigateDataList()
        {
            string opinionOneToString = webDriver.FindElement(opinionOne).GetAttribute("value");
            webDriver.FindElement(dataList).SendKeys(opinionOneToString);
            Actions action = new Actions(webDriver);
            action.MoveToElement(webDriver.FindElement(dataList)).MoveByOffset(0, -50).Click().Build().Perform(); // it's working, the button disappeared
        }

        public void NavigateDataList(By opinion)
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
            NavigateDataList();
        }

        public Opinions(IWebDriver driver, int option, string any) : base(driver)
        {
            if (option == 1)
            {
                this.NavigateDataList(opinionOne);
            }
            else if (option == 3)
            {
                this.NavigateDataList(opinionThree);
            }
            else if (option == 2)
            {
                this.NavigateDataList(opinionTwo);
            }
            else
                this.NavigateDataList(opinionThirteen);
                
        }

        public static String letMeSeeIfThisUglyIdeaWorks(IWebDriver driver, bool disableQuit)
        {
            string test = "test";
            string resultInWords = "";
            string didItReallyWorkQuestionMarkX3 = "";
            string returnThis = "";

            try
            {
                Opinions multipleOpinionsTest = new Opinions(driver, 3, test);

                Assert.IsFalse(driver.FindElement(Datalist.hideousButton).Displayed);

                // Reporting to a file starts here

                bool result = driver.FindElement(Datalist.hideousButton).Displayed;
                resultInWords = $"For option 3 the button is displayed. Expected: False, Actual: {result}";
                didItReallyWorkQuestionMarkX3 = "Did it really work?";
                System.Console.WriteLine(resultInWords);

                using (StreamWriter sw = File.AppendText("report.txt"))
                {
                    sw.Write(Environment.NewLine + resultInWords);
                    sw.Write(Environment.NewLine + didItReallyWorkQuestionMarkX3);
                }

                // Reporting to a file ends here

            }
            finally
            {
                if (disableQuit == false)
                driver.Quit();
            }

            returnThis = resultInWords + didItReallyWorkQuestionMarkX3;
            return returnThis;

        }

    }

    public class Reporting : Opinions
    {
        public Reporting(IWebDriver driver) : base(driver)
        {
            anotherIdeaOfMine(driver);
        }

        public Reporting(IWebDriver driver, string any) : base(driver, any)
        {

        }

        public Reporting(IWebDriver driver, int option, string any) : base(driver)
        {

        }

        public static By textArea = By.Id("reportHere");

        public void anotherIdeaOfMine(IWebDriver drive)
        {
            String report = letMeSeeIfThisUglyIdeaWorks(drive, true);
            webDriver.FindElement(textArea).SendKeys(report);
        }
    }

    public class Submitting : Reporting
    {
        public Submitting(IWebDriver driver) : base(driver)
        {
            sendReport(driver);
        }

        public static By submitReportButton = By.Id("submitReport");
        public static By readReport = By.Id("readReport");

        public void sendReport(IWebDriver driver)
        {
            webDriver.FindElement(submitReportButton).Click();
        }
    }

    public class Erasing : Submitting
    {
        public Erasing(IWebDriver driver) : base(driver)
        {
            clearReportHistory(driver);
        }

        public static By clrReportButton = By.Id("clrReportHistory");

        public void  clearReportHistory(IWebDriver driver)
        {
            webDriver.FindElement(clrReportButton).Click();
        }
    }
        


}