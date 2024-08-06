using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace Shipping.Utilities
{
    public class CrossBrowser : Base
    {
        //public WebDriver _driver;

        //protected CrossBrowser(BrowserType type)
        //{
        //    _driver = WebDriver(type);
        //}

        //public enum BrowserType
        //{
        //    IE11,
        //    Chrome
        //}

        //[TearDown]
        //public void Close()
        //{
        //    _driver.Close();
        //}

        //public static IWebDriver WebDriver(BrowserType type)
        //{
        //    IWebDriver driver = null;

        //    switch (type)
        //    {
        //        case BrowserType.Chrome:
        //            driver = ChromeDriver();
        //            break;

        //        case BrowserType.IE11:
        //            driver = IeDriver();
        //            break;
        //    }

        //    return driver;
        //}

        //private static IWebDriver IeDriver()
        //{
        //    InternetExplorerOptions options = new InternetExplorerOptions();
        //    options.EnsureCleanSession = true;
        //    options.IgnoreZoomLevel = true;
        //    IWebDriver driver = new InternetExplorerDriver(options);
        //    return driver;
        //}

        //private static IWebDriver ChromeDriver()
        //{
        //    ChromeOptions options = new ChromeOptions();
        //    IWebDriver driver = new ChromeDriver(options);
        //    return driver;
        //}



    }
}
