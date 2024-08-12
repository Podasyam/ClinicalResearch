using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Reflection;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Shipping.Utilities
{   
    public class Base
    {
        
        public static IWebDriver _driver;

        public void InitDriver(string browser)
        {
            try
            {
                if (browser.Equals("chrome"))
                {
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    Serilog.Log.Debug("Navigate to {0} on chrome browser");
                }
                else if (browser.Equals("Edge"))
                {
                    //new DriverManager().SetUpDriver(new EdgeConfig());
                    _driver = new EdgeDriver();                    
                    Serilog.Log.Debug("Navigate to {0} on edge browser");
                }
                else                 
                { 
                    Assert.Fail("The browser does not exist");
                    Serilog.Log.Debug("Browser was not launched");
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                _driver.Manage().Window.Maximize();
            }
            catch (NoSuchDriverException ex)
            {
                Console.WriteLine(ex.Message);
                Serilog.Log.Debug("driver was not initiated");

            }
        }

        public static void Goto(string url)
        {
            _driver.Url = url;
        }
        public string Title
        {
            get { return _driver.Title; }
        }

        public static void CaptureScreenshot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)_driver;
            screenshot.GetScreenshot().SaveAsFile("screenshot" + DateTime.Now + ".png"); ;
            
        }

        public static void ScrollWindow()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0,430)");

        }

        public static void QuitDriver()
        {
            try
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    Serilog.Log.Debug("driver closed");
                }
                             
                 Console.WriteLine("Driver has been closed successfully");// Comment added
     
            }
            catch (Exception ex)
            {              
                Console.WriteLine(ex.Message);
                Console.WriteLine("NullDriverException");// Comment added
            }

        }

        //public static IEnumerable<string> BrowserToRunWith()
        //{
        //    string[] browsers = { "chrome", "Edge" };

        //    foreach (string b in browsers)
        //    {

        //        yield return b;

        //    }


        //}

        public static void WindowHandles()
        {

            string parentWindowHandle = _driver.CurrentWindowHandle;

            List<string> windowHandles = _driver.WindowHandles.ToList();
            foreach (var handles in windowHandles)
            {

                _driver.SwitchTo().Window(handles);
            
            }
        
        }


    }
}
