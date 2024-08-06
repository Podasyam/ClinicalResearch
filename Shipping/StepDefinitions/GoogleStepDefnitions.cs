using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.CSS;
using Shipping.Utilities;
using System;
using TechTalk.SpecFlow.CommonModels;

namespace Shipping.StepDefinitions
{
    
   [Binding]
   [Parallelizable]
    public sealed class GoogleStepDefnitions : Base
    {
        [Given(@"Launch the browser (.*)")]
        //[TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void GivenLaunchTheBrowser(string browserName)
        {
            
            InitDriver(browserName); // Initiated driver
            Goto("https://www.google.com"); // added URL and push to branch
            var driverTitle = Title;
            Assert.AreEqual("Google", driverTitle); // Added Assert//
            
            //Assert.That(driverTitle, Is.EqualTo("Google").Or.EqualTo("Goo"));
            //Assert.That(driverTitle, Is.Not.Null);
           
        }

        [When(@"User enter text Selenium")]
        public void WhenUserEnterTextSelenium()
        {
            
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
                QuitBrowser();// Browser was closed.
                //Assert.Pass("Execution completed and driver was closed successfully");
            }
            catch (NullReferenceException ex)
            {

                Console.WriteLine(ex.Message, "Issue in closing the driver");
            
            }


        }


    }
}
