using NUnit.Framework;
using Shipping.Utilities;
using System;
using TechTalk.SpecFlow;

namespace Shipping.StepDefinitions
{
    [Binding]
    [Parallelizable]

    public class GmailStepDefinitions : Base
    {

        
        [Given(@"Launch google browser")]
        [Test]
        [TestCaseSource(typeof(Base), "BrowserToRunWith")]
        public void GivenLaunchGoogleBrowser()
        {
            InitDriver("test"); // Initiated driver

            Goto("https://www.google.com"); // added URL and push to branch

            var driverTitle = Title;
            Assert.AreEqual(driverTitle, "Google"); // Added Assert//
            Assert.That(driverTitle, Is.EqualTo("Google").Or.EqualTo("Goo"));

        }

        [When(@"Click on gmail")]
        public void WhenClickOnGmail()
        {
            


        }

        [Then(@"gmail should open")]
        public void ThenGmailShouldOpen()
        {
            
        }

        [Then(@"Close browser")]
        public void ThenCloseBrowser()
        {

            // Browser was closed.

        }
    }
}
