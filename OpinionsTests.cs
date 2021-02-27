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

    }

}