using NPOI.SS.UserModel;
using OpenQA.Selenium;
using Shipping.Utilities;
using System.Xml.Linq;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace Shipping.PageElements
{
    public class LoginPage
    {
        private IWebDriver _driver;
        // Private field
        private IWebElement _searchTextBox;
        private IWebElement _searchButton;
        private IWebElement _searchResultLabel;
        public LoginPage(IWebDriver driver)
        {

            _driver = driver;

        }
        //Usernametextbox//addedbySyam//addedcomment on 13-08-24
        public IWebElement TxtSearch
        {     //get { return _driver.FindElement(By.XPath("//p[contains(text(),'TextBox :')]/descendant::input[@id='fname']")); }}
            get
            {           
                try
                {
                    // Attempt to find the element if not already found
                    if (_searchTextBox == null)
                    {                        
                        _searchTextBox = _driver.FindElement(By.CssSelector("input[id='search'][name='q']"));                       
                        
                    }
                    return _searchTextBox;
                }
                catch (NoSuchElementException ex)
                {
                    // Handle the case where the element is not found
                    Console.WriteLine($"Element not found: {ex.Message}");
                    Serilog.Log.Debug($"Element not found: {ex.Message}");
                    return null; // Optionally return null or throw a custom exception
                }
                catch (Exception ex)
                {
                    // Handle other potential exceptions
                    Console.WriteLine($"Error getting element: {ex.Message}");
                    Serilog.Log.Debug($"Error getting element: {ex.Message}");
                    return null; // Optionally return null or throw a custom exception
                }
            }

            //set
            //{
            //    try
            //    {
            //        // Example: If you want to perform some operation on the element while setting it
            //        if (value != null)
            //        {
            //            value.Click(); // Example operation
            //            _userName = value;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle any exceptions that occur during the set operation
            //        Console.WriteLine($"Error setting element: {ex.Message}");
            //        _userName = null; // Optionally reset the element
            //    }

            //}

        }
        public IWebElement BtnSearch
        { get { return _driver.FindElement(By.CssSelector("#action search")); } }

        public IWebElement LblSearchResult
        { get { return _driver.FindElement(By.XPath("//span[contains(text(),'Search results for:')]")); } }


      

    }
}
