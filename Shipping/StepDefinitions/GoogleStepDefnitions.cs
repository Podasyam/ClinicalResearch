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
            Goto("https://artoftesting.com/samplesiteforselenium"); // added URL and push to branch           
            var driverTitle = Title;
            Assert.AreEqual("Sample Webpage for Selenium Automation Practice | ArtOfTesting", driverTitle); // Added Assert//
            //Assert.That(driverTitle, Is.EqualTo("ArtOfTesting").Or.EqualTo("Art"));
            //Assert.That(driverTitle, Is.Not.Null);
        }

        [When(@"User enter text Selenium")]
        public void WhenUserEnterTextSelenium()
        {
            try
            {
                LoginPageFlow loginPageFlow = new LoginPageFlow(_driver);
                loginPageFlow.EnterUserName();
                Serilog.Log.Debug("Username has been entered in username textbox");
            }
            catch(NoSuchElementException ex)
            {

                Console.WriteLine(ex.Message);
                Serilog.Log.Debug("UserName is not entered", ex.Message);
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


    }
}
