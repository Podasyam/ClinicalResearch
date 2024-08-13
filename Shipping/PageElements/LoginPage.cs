using NPOI.SS.UserModel;
using OpenQA.Selenium;
using Shipping.Utilities;
using System.Xml.Linq;

namespace Shipping.PageElements
{
    public class LoginPage
    {
        private IWebDriver _driver;
        // Private field
        private IWebElement _userName;
        public LoginPage(IWebDriver driver)
        {

            _driver = driver;

        }
        //Usernametextbox//addedbySyam//addedcomment on 13-08-24
        public IWebElement TxtUserName
        { get { return _driver.FindElement(By.XPath("//p[contains(text(),'TextBox :')]/descendant::input[@id='fname']")); }}

        public IWebElement TxtPassword
        { get { return _driver.FindElement(By.XPath("//p[contains(text(),'TextBox :')]/descendant::input[@id='fname']")); } }

    }
}
