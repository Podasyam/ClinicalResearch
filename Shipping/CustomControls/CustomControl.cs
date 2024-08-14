using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shipping.PageElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.CustomControls
{
    public class CustomControl
    {
        private static IWebDriver _driver;        
        //private WebDriverWait _wait;
        public CustomControl(IWebDriver driver)
        {
            _driver = driver;
        }
        public static void EnterText(IWebElement webElement, string value)
        {                       
            // Use the custom wait method
            //WaitForCondition(webElement,TimeSpan.FromSeconds(10));
            webElement.SendKeys(value);            
        }

        public static void Click(IWebElement webElement) => webElement.Click();

        public static void ComboBox(IWebElement controlName, string value)
        {
            controlName = _driver.FindElement(By.XPath(""));
            controlName.Clear();
            controlName.SendKeys(value);               
        }

        public static void SelectByText(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

        public static void LableMessage(IWebElement webElement, string text)
        {
            webElement.Equals(text);
        }

        // Custom wait method
        public static void WaitForCondition(By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(_driver, timeout);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));


        }
    }
}
