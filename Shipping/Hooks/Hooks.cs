using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Shipping.StepDefinitions;
using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using Shipping.Variables;
using System.Diagnostics;
using Log = Serilog.Log;
using AventStack.ExtentReports.Reporter.Config;
using Shipping.Utilities;
using TechTalk.SpecFlow;
using System.Reflection;
using BoDi;

namespace Shipping.Hooks
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports extent;
        private static ExtentTest feature;
        private ExtentTest scenario;
        private ExtentTest step;        
                //public static ExtentSparkReporter extentSparkReporter;
        [ThreadStatic]// The [ThreadStatic] attribute in C# is used to specify that a static field is unique for each thread. This means that each thread has its own separate instance of the static field, rather than sharing the same instance across all threads.
            
        private static ExtentSparkReporter extentSparkReporter;

        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyyHHmmss") 
            + Path.DirectorySeparatorChar;

        //static string screenshotpath = System.IO.Directory.GetParent(@"../../../").FullName
        //   + Path.DirectorySeparatorChar + "TestReports"
        //   + Path.DirectorySeparatorChar + "ExtentSparkReport_" + DateTime.Now.ToString("ddMMyyyyHHmmss") 
        //   + ".html" + Path.DirectorySeparatorChar;


        //In C#, a static field is a field that belongs to the type itself rather than to any specific instance of the type. This means that all instances of the class share the same static field. If you change the value of a static field, the change is reflected across all instances of the class.
        public static ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        [BeforeTestRun]
        //A static method in C# is a method that belongs to the type (class) itself rather than to any specific instance of the class. This means that you can call a static method without creating an instance of the class.
        public static void BeforeTestRun()
        {   //Configuration file access
            config = new ConfigSetting();
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);


            extent = new ExtentReports();
            var sparkReporter = new ExtentSparkReporter(reportpath);
            sparkReporter.Config.DocumentTitle = "Test Report";
            sparkReporter.Config.ReportName = "My Test Suite Report";
            sparkReporter.Config.Theme = Theme.Dark;
            extent.AttachReporter(sparkReporter);

            //Logs
            var levelswitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                                    .MinimumLevel.ControlledBy(levelswitch)
                                    .WriteTo.File(new JsonFormatter(), reportpath + @"\Logs").CreateLogger();
                                        //, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message}{NewLine} ",
                                        // rollingInterval: RollingInterval.Day).CreateLogger();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {  
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);
            Log.Information("Select feature file {0} to run", featureContext.FeatureInfo.Title);
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            //Get scenario name
            scenario = feature.CreateNode(scenarioContext.ScenarioInfo.Title);
            Log.Information("Select feature file {0} to run", scenarioContext.ScenarioInfo.Title);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            Log.Information("Select feature file {0} to run", scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Base.QuitDriver();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                scenario.Log(Status.Pass, stepType + " " + scenarioContext.StepContext.StepInfo.Text);
                string base64 = GetScreenshot();
                step.Log(Status.Pass, scenarioContext.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }
            else if (scenarioContext.TestError != null)
            {
                scenario.Log(Status.Fail, stepType + " " + scenarioContext.StepContext.StepInfo.Text);
                scenario.Log(Status.Fail, scenarioContext.TestError.Message);
                string base64 = GetScreenshot();
                step.Log(Status.Fail, scenarioContext.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
            }

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
           // extent.Flush();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
        public string GetScreenshot()
        {
            //return ((ITakesScreenshot)StepDefinition.webDriver).GetScreenshot().AsBase64EncodedString;
            var ScreenshotPath = Path.GetFullPath(reportpath);
            var screenshot = ((ITakesScreenshot)Base._driver).GetScreenshot();
            var img = screenshot.AsBase64EncodedString;
            return img;
        }

        //: 'Could not find a part of the path 'C:\Users\User\source\repos\ClinicalResearch\Shipping\Result\Result_12082024234807\'.'
    }
       
      
    }
