using NUnit.Framework;
using Shipping.Utilities;
using System;
using TechTalk.SpecFlow;
using static Shipping.Utilities.CrossBrowser;

namespace Shipping.StepDefinitions
{
    [Binding]
    [Parallelizable]
    //[TestFixture(BrowserType.Chrome)]
    //[TestFixture(BrowserType.IE11)]
    public class CrossBrowserStepDefinitions : CrossBrowser
    {
        //        public CrossBrowserStepDefinitions(BrowserType browser) : base(browser)
        //        {

        //        }

        //        [Test]
        //        public void Test1()
        //        {
        //            _driver.Navigate().GoToUrl("https://www.google.co.uk/");
        //            Assert.AreEqual("https://www.google.co.uk/", _driver.Url);
        //        }
        //    }

    }
}