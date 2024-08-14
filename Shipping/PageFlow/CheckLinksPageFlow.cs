using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.PageFlow
{
    public class CheckLinksPageFlow
    {
        private IWebDriver _driver;

        public CheckLinksPageFlow(IWebDriver driver)
        {
            _driver = driver;
        
        }

        public async void CheckWebPageLinks()
        {
            IList<IWebElement> links = _driver.FindElements(By.TagName("a"));
            List<string> brokenLinks = new List<string>();

            HttpClient httpClient = new HttpClient();

            foreach (IWebElement link in links)
            {
                string url = link.GetAttribute("href");
                if (string.IsNullOrEmpty(url))
                {
                    Serilog.Log.Debug(link + " " + "url is empty:" );
                    continue;
                }


                try
                {
                    string route = link.GetAttribute("href");
                    var response = await httpClient.GetAsync(route);
                    if (!response.IsSuccessStatusCode)
                    {
                        Serilog.Log.Debug($"Broken link found: {url} (Status Code: {response.StatusCode})");
                        brokenLinks.Add(url);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error accessing {url}: {e.Message}");
                    Serilog.Log.Debug($"Error accessing {url}: {e.Message}");
                    brokenLinks.Add(url);
                }

            }
            // Output the results   
                if (brokenLinks.Count == 0)
                {
                Console.WriteLine("No broken links found.");
                }
                else
                {
                Console.WriteLine($"Total broken links: {brokenLinks.Count}");
                    foreach (string brokenLink in brokenLinks)
                    {
                    Console.WriteLine(brokenLink);
                    }
                }


        }


    }
}
