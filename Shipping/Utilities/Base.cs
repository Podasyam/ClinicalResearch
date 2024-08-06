using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;


namespace Shipping.Utilities
{   
    public class Base
    {
        
        public static WebDriver _driver;

        public void InitDriver(string browser)
        {
            try
            {
                if (browser.Equals("chrome"))
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                    _driver.Manage().Window.Maximize();
                    

                    Console.WriteLine("Initilize chrome");
                }
                else if (browser.Equals("Edge"))
                {
                    _driver = new EdgeDriver();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
                    _driver.Manage().Window.Maximize();
                   
                    Console.WriteLine("Initilize Edge");
                }
                
                
                else 
                
                { Assert.Fail("The browser does not exist"); }
            }

            catch (NoSuchDriverException ex)
            {

                //((ITakesScreenshot) _driver)
                //.GetScreenshot().SaveAsFile("",T.Jpg);
                //Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
                
            }
        }

        public void Goto(string url)
        {
            _driver.Url = url;
        }
        public string Title
        {
            get { return _driver.Title; }
        }

        public void QuitBrowser()
        {
            try
            {
                 _driver.Quit();
                
                 Console.WriteLine("Driver has been closed successfully");// Comment added
     
            }
            catch (Exception ex)
            { 
             
                Console.WriteLine(ex.Message);
                Console.WriteLine("Drive reference was null");// Comment added
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

    }
}
