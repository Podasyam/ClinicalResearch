using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.CSS;
using Shipping.PageFlow;
using Shipping.Utilities;
using Shipping.Hooks;
using System;
using System.Configuration;
using TechTalk.SpecFlow.CommonModels;

namespace Shipping.StepDefinitions
{
    
   [Binding]
   [Parallelizable]
    public class GoogleStepDefnitions : Base
    {
        [Given(@"Launch the browser (.*)")]
        //[TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void GivenLaunchTheBrowser(string browserName)
        {
            InitDriver(browserName); // Initiated driver
            //Goto(Hooks.config.AppiumUrl.ToLower());                        // 
            Goto("https://magento.softwaretestingboard.com/"); // added URL and push to branch           
            var driverTitle = Title;
            Assert.AreEqual("Home Page", driverTitle); // Added Assert//
            //Assert.That(driverTitle, Is.EqualTo("ArtOfTesting").Or.EqualTo("Art"));
            //Assert.That(driverTitle, Is.Not.Null);
        }

        [When(@"User enter text Selenium")]
        public void WhenUserEnterTextSelenium()
        {
            try
            {
                var loginPageFlow = new LoginPageFlow(_driver);
                loginPageFlow.SearchResults();
                Serilog.Log.Debug("text has been entered in search textbox");
            }
            catch(NoSuchElementException ex)
            {

                Console.WriteLine(ex.Message);
                Serilog.Log.Debug("text is not entered in search textbox", ex.Message);
            }

        }

        [When(@"User click on Search button")]
        public void WhenUserClickOnSearchButton()
        {
            
        }

        [Then(@"Selenium search results should display")]
        public void ThenSeleniumSearchResultsShouldDisplay()
        {
            
        }

        [Then(@"Close the Browser")]
        public void ThenCloseTheBrowser()
        {

            try
            {
               
                //QuitBrowser();// Browser was closed.
                //Assert.Pass("Execution completed and driver was closed successfully");
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message, "Issue in closing the driver");
            
            }


        }

        [When(@"User click on cloths link")]
        public void WhenUserClickOnClothsLink()
        {
            
        }

        [Then(@"User should navigate to cloths webpage")]
        public void ThenUserShouldNavigateToClothsWebpage()
        {
            
        }





    }
}
