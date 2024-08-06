using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Utilities
{

   
    internal class Pratice
    {

        IWebDriver driver = new FirefoxDriver();
        public void DynamicWebTable()
        {
            // Open the browser for Automation
            
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // xpath of html table
            var elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            string strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
            Console.WriteLine("");
            
        }

        public void DropdownList()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//label[@name='Cities']/following-sibling :: div/select")));

            dropdown.SelectByValue("");
            dropdown.SelectByText("");

           // List<IWebElement> sites = dropdown.Options;


            var london = driver.FindElement(By.XPath("div")).Text;



            //_driver.FindElement(RelativeBy(By.TagName("input")).Above(passwordField));

            //WebElement element = driver.FindElement(By.Id("Sex-Male"));
            //bool status = element.Selected;

            //Or can be written as

            //bool staus = driver.FindElement(By.Id("Sex-Male")).Selected;

           // IWebElement element2 = driver.FindElement(By.XPath("anyLink"));
           // String linkText = element2.Text;





        }

        public void Load_retrieves_file()
        {
            //// ARRANGE
            //var fileName = "my_file.txt";

            //var sut = new FileLoader();

            //// ACT
            //var result = sut.Load(fileName);

            //// ASSERT        
            //Assert.That(result, Is.Not.Null);
        }


        [TestFixture]
        public class Tests
        {
            //[OneTimeSetUp]
            //public void OneTimeSetUp() => TestContext.Progress.Writeline("Tests:OneTimeSetUp");

            //[SetUp]
            //public void Setup() => TestContext.Progress.Writeline("Tests:SetUp");

            //public Tests() => TestContext.Progress.Writeline("Tests:Constructor");

            //[Test]
            //public void Test1() => TestContext.Progress.Writeline("Tests:Test1");

            //[Test]
            //public void Test2() => TestContext.Progress.Writeline("Tests:Test2");

            //[TearDown]
            //public void TearDown() => TestContext.Progress.Writeline("Tests:TearDown");

            //[OneTimeTearDown]
            //public void OneTimeTearDown() => TestContext.Progress.Writeline("Tests:OneTimeTearDown");
        }

        [Test]
        public async Task LoadAsync_retrieves_file()
        {
            // ARRANGE
            //var fileName = "my_file.txt";

            //var sut = new FileLoader();

            //// ACT
            //var result = await sut.LoadAsync(fileName);

            //// ASSERT
            //Assert.That(result, Is.Not.Null);
        }
    }




}

