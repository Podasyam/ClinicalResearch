using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Shipping.Utilities
{   
    public class Common
    {
        public WebDriver _driver;

        public void InitDriver()
        {
            try
            {                
                _driver = new ChromeDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
                _driver.Manage().Window.Maximize();
               
            }
            catch (NoSuchDriverException ex)
            {

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
            }
            catch (Exception ex)
            { 
             
                Console.WriteLine(ex.Message);
                Console.WriteLine("Drive reference was null");
            }
        }
    }
}
