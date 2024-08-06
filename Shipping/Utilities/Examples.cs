using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.DevTools.V125.Audits;
using System.Runtime.InteropServices;
using FluentAssertions.Execution;


namespace Shipping.Utilities
{   
    public class Examples
    {
        
        public static WebDriver _driver;

        public void InitDriver(string browser)
        {   
            try
            {
                if (browser.Equals("chrome"))
                {
                    _driver = new ChromeDriver();
                   
                    Console.WriteLine("Initilize chrome");
                }
                else if (browser.Equals("Edge"))
                {
                    _driver = new EdgeDriver();
                   
                    Console.WriteLine("Initilize Edge");
                }
                else
                    _driver = new ChromeDriver();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("");

                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;


                WebDriverWait explicitWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                explicitWait.Until(ExpectedConditions.ElementExists(By.XPath("")));
                explicitWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("")));
                explicitWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("")));
                explicitWait.IgnoreExceptionTypes(typeof (ElementNotSelectableException));
                explicitWait.PollingInterval = TimeSpan.FromMilliseconds(2);
                

                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);

                var button = _driver.FindElement(By.XPath("//form[@data-testid='royal_login_form']/descendant::button[contains(@id='u_0_5')]"));

                IWebElement table = _driver.FindElement(By.XPath("table"));
                List<IWebElement> trList = new List<IWebElement>(table.FindElements(By.TagName("tr")));

                int rowCount = trList.Count();
                for (int i = 1; i < rowCount; i++)
                {
                    string firstName = _driver.FindElement(By.XPath("//table/tr[" + i + "]/td")).Text;
                    if (firstName.Contains("Will"))
                    { 
                    
                      
                    
                    }
                
                
                
                }

                int[] arr = { 1, 2, 4, 3 };
                    foreach (var value in arr)
                     {
                        Console.WriteLine(value);
                     }

                Array.Sort(arr);
                Array.Reverse(arr);

                    foreach (var rev in arr)
                    {
                    Console.WriteLine(rev);

                    }


                // Switch the control of 'driver' to the Alert from main Window
                IAlert simpleAlert = _driver.SwitchTo().Alert();

                // '.Text' is used to get the text from the Alert
                String alertText = simpleAlert.Text;
                Console.WriteLine("Alert text is " + alertText);

                // '.Accept()' is used to accept the alert '(click on the Ok button)'
                simpleAlert.Accept();

                Actions builder = new Actions(_driver);
                builder.MoveToElement(_driver.FindElement(By.Id("Content_AdvertiserMenu1_LeadsBtn"))).Click().Perform();
                IWebElement element = _driver.FindElement(By.XPath(""));
                builder.KeyDown(element, Keys.Shift).SendKeys("").KeyUp(Keys.Shift);

                IWebElement source = _driver.FindElement(By.XPath(""));

                IWebElement target = _driver.FindElement(By.XPath(""));

                builder.DragAndDrop(source, target).Perform();

                builder.SendKeys(Keys.Control);
                builder.SendKeys("A");
                builder.SendKeys(Keys.Control);
                builder.SendKeys("C");
                builder.ContextClick().Perform();
                    
            }
            catch (NoSuchDriverException ex)
            {

                //((ITakesScreenshot) _driver)
                //.GetScreenshot().SaveAsFile("",T.Jpg);
                //Console.WriteLine(ex.Message);
            
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
                Console.WriteLine("Drive reference was null");// Comment added
            }

        }

        public static IEnumerable<String> BrowserToRunWith()
        {

            String[] browsers = { "chrome", "firefox" };
            foreach (String browser in browsers)
            {
                yield return browser;

            }

        }

    }
}
