using NUnit.Framework;
using OpenQA.Selenium;
using Shipping.Utilities;

namespace Shipping.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefnitions
    {
        Common commonObj = new Common();

        [Given(@"Launch the browser")]
        public void GivenLaunchTheBrowser()
        {
            
            commonObj.InitDriver(); // Initiated driver
            commonObj.Goto("https://www.google.com"); // added URL and push to branch
            var driverTitle = commonObj.Title;
            Assert.AreEqual(driverTitle,"Google");
       
        }

        [When(@"User enter the username and password")]
        public void WhenUserEnterTheUsernameAndPassword()
        {
            
        }

        [When(@"User click on Login button")]
        public void WhenUserClickOnLoginButton()
        {
        }    

        [Then(@"User has been logged in successfull message should display")]
        public void ThenUserHasBeenLoggedInSuccessfullMessageShouldDisplay()
        {
           
        }

        [Then(@"Home page should display")]
        public void ThenHomePageShouldDisplay()
        {
            
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {
           
            commonObj.QuitBrowser();// Browser was closed.
            
        }

    }
}
