using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Utilities
{
    public class ExtentReport : Base
    {
        public IWebDriver _driver;
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public ExtentReport(IWebDriver driver)
        {

            _driver = driver;
        }

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentSparkReporter(testResultPath + "\"Spark.html\"");
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            //htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Youtube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public string addScreenshot(ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)_driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation+ @"\img.png");
            return screenshotLocation;
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

    }
}
