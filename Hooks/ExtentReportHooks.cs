// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Gherkin.Model;
// using AventStack.ExtentReports.Reporter;
// using AventStack.ExtentReports.Reporter.Config;
// using log4net;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Support.Extensions;
// using Reqnroll;
// using sampleProject.StepDefinitions;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Text;
// using System.Threading;

// namespace sampleProject.Hooks
// {
//     [Reqnroll.Binding]
//     internal class ExtentReportHooks
//     {

        
//         private static ExtentReports extent;
        
//         public static ThreadLocal<ExtentTest> exTest = new();
//          private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
//         private static ExtentTest feature;
//         public static ExtentTest scenario;


//         private static string reportPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ExtentReports");
//         private static string reportFile = Path.Combine(reportPath, "ExtentReports.html");
//         private readonly ScenarioContext _scenarioContext;
//         public static ExtentTest GetExtentTest(){
//             return exTest.Value;
//         }

//     public ExtentReportHooks(ScenarioContext scenarioContext)
//     {
//         _scenarioContext = scenarioContext;
//     }


//         [BeforeTestRun]
//         public static void InitializeReport()
//         {
//             if(!Directory.Exists(reportFile)) { 
            
//                 Directory.CreateDirectory(reportPath);
            
//             }


//             var htmlReporter = new ExtentSparkReporter(reportFile);
//             htmlReporter.Config.Theme=Theme.Standard;
//             htmlReporter.Config.DocumentTitle="Your test name";
//             htmlReporter.Config.ReportName="Enter your TestReportName";
//             htmlReporter.Config.Encoding="utf-8";
//             extent = new ExtentReports();
//             extent.AttachReporter(htmlReporter);
//             extent.AddSystemInfo("Tester name","Enter your tester name Ravinder Budhwan");


//         }

//         [AfterTestRun]
//         public static void FlushReport()
//         {

//             extent.Flush();
//         }
//         static ScenarioContext scenarioContext;

//         [BeforeFeature]
//         public static void BeforeFeature(FeatureContext featureContext)
//         {


//             feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        

//         }

//         [BeforeScenario]
//         public void BeforeScenario()
//         {

//             scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
//         //    scenarioContext=scenarioContent;
//         //    scenarioContext["ExtentTest"] = feature;
//         //    scenario.Info("ho ho ho");

//         }


//         // [AfterStep]
//         // public void AfterStep()
// //         {

// //  var test = (ExtentTest)_scenarioContext["ExtentTest"];
// //         // var stepInfo = _scenarioContext.StepContext.StepInfo;

// //             var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
// //             var stepInfo = ScenarioStepContext.Current.StepInfo.Text;

// //             if(scenarioContext.TestError == null)
// //             {

// //                 if (stepType == "Given")
// //                     scenario.CreateNode<Given>(stepInfo);
// //                 else if (stepType == "When")
// //                     scenario.CreateNode<When>(stepInfo);
// //                 else if (stepType == "Then")
// //                     scenario.CreateNode<Then>(stepInfo);
// //                 else if (stepType == "And")
// //                     scenario.CreateNode<And>(stepInfo);
                    


// //             }
// //             else
// //             {

// //                 if (stepType == "Given")
// //                     scenario.CreateNode<Given>(stepInfo).Fail(scenarioContext.TestError.Message);
// //                 else if (stepType == "When")
// //                     scenario.CreateNode<When>(stepInfo).Fail(scenarioContext.TestError.Message);
// //                 else if (stepType == "Then")
// //                     scenario.CreateNode<Then>(stepInfo).Fail(scenarioContext.TestError.Message);
// //                 else if (stepType == "And")
// //                     scenario.CreateNode<And>(stepInfo).Fail(scenarioContext.TestError.Message);

// // //                       ITakesScreenshot ts= (ITakesScreenshot)stepDefinitions.driver;
// // //             var screenshot1= ts.GetScreenshot().AsBase64EncodedString;
// // // scenario.AddScreenCaptureFromBase64String(MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot1, "screenShotName").Build().ToString(),"");
       
       
// //         //     scenario.Fail("he he",MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, "screenShotName").Build());

// //         DateTime currentTime = DateTime.Now;
// //             String fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

// //             Screenshot screenshot = stepBase.GetDriver().TakeScreenshot();

// //                  string snapshotPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Snapshots/");
        
// //         screenshot.SaveAsFile(Path.Combine(snapshotPath, fileName));
// //         var fullpath=snapshotPath+fileName;
// //         scenario.AddScreenCaptureFromPath(snapshotPath+fileName);
// //         // scenario.AddScreenCaptureFromPath("/Users/ravinder.budhawan/Desktop/Octopus/Automation/sampleProject/sampleProject/Snapshots/2025-05-16_09-42-50.jpg");
       
            
// //             }

// //         }


// [AfterStep]
// public void AfterStep()
// {
//     var stepInfo = _scenarioContext.StepContext.StepInfo;
//     string stepText = stepInfo.Text;
//     string stepType = stepInfo.StepDefinitionType.ToString();

//     if (_scenarioContext.TestError == null)
//     {
//         if (stepType == "Given")
//             scenario.CreateNode<Given>(stepText);
//         else if (stepType == "When")
//             scenario.CreateNode<When>(stepText);
//         else if (stepType == "Then")
//             scenario.CreateNode<Then>(stepText);
//         else if (stepType == "And")
//             scenario.CreateNode<And>(stepText);
//     }
//     else
//     {
//         if (stepType == "Given")
//             scenario.CreateNode<Given>(stepText).Fail(_scenarioContext.TestError.Message);
//         else if (stepType == "When")
//             scenario.CreateNode<When>(stepText).Fail(_scenarioContext.TestError.Message);
//         else if (stepType == "Then")
//             scenario.CreateNode<Then>(stepText).Fail(_scenarioContext.TestError.Message);
//         else if (stepType == "And")
//             scenario.CreateNode<And>(stepText).Fail(_scenarioContext.TestError.Message);

//         // Capture screenshot on failure
//         DateTime currentTime = DateTime.Now;
//         string fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

//         Screenshot screenshot = stepBase.GetDriver().TakeScreenshot();
//         string snapshotPath = Path.Combine(
//             Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName,
//             "Snapshots/"
//         );

//         if (!Directory.Exists(snapshotPath))
//         {
//             Directory.CreateDirectory(snapshotPath);
//         }

//         string fullPath = Path.Combine(snapshotPath, fileName);
//         screenshot.SaveAsFile(fullPath);
//         scenario.AddScreenCaptureFromPath(fullPath);
//     }
// }






//     }
// }













// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Gherkin;
// using AventStack.ExtentReports.Reporter;
// using AventStack.ExtentReports.Extensions;
// using Reqnroll;
// using System;
// using System.IO;
// using System.Threading;
// using sampleProject.StepDefinitions;
// using OpenQA.Selenium.Support.Extensions;
// using OpenQA.Selenium;
// using AventStack.ExtentReports.Gherkin.Model;

// [Binding]
// public class ExtentReportHooks
// {
//     private static ExtentReports _extent;
//     private static ExtentSparkReporter _htmlReporter;

//     // Thread-safe test instance
//     private static ThreadLocal<ExtentTest> _feature = new ThreadLocal<ExtentTest>();
//     private static ThreadLocal<ExtentTest> _scenario = new ThreadLocal<ExtentTest>();
//      private readonly ScenarioContext _scenarioContext;

//     // Inject ScenarioContext through constructor
//     public ExtentReportHooks(ScenarioContext scenarioContext)
//     {
//         _scenarioContext = scenarioContext;
//     }

//     [BeforeTestRun(Order = 0)]
//     public static void BeforeTestRun()
//     {
//         string reportPath = ("./../../ExtentReports/ExtentReport123.html");
//         _htmlReporter = new ExtentSparkReporter(reportPath);
//         _htmlReporter.Config.DocumentTitle = "Reqnroll Test Report";
//         _htmlReporter.Config.ReportName = "Automation Test Results";
       

//         _extent = new ExtentReports();
//         _extent.AttachReporter(_htmlReporter);
//     }

//     [AfterTestRun]
//     public static void AfterTestRun()
//     {
//         _extent.Flush();
//     }

//     [BeforeFeature]
//     public static void BeforeFeature(FeatureContext featureContext)
//     {
//         _feature.Value = _extent.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
//     }

//     [BeforeScenario]
//     public void BeforeScenario(ScenarioContext scenarioContext)
//     {
//         _scenario.Value = _feature.Value.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioContext.ScenarioInfo.Title);
//     }

//     [AfterStep]
//     public void InsertReportingSteps(ScenarioContext scenarioContext)
//     {
//         var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
//         var stepInfo = scenarioContext.StepContext.StepInfo;

//         if (scenarioContext.TestError == null)
//         {
//             _scenario.Value.CreateNode(new GherkinKeyword(stepType), stepInfo.Text);
//         }
//         else
//         {
//             _scenario.Value.CreateNode(new GherkinKeyword(stepType), stepInfo.Text)
//                 .Fail(scenarioContext.TestError.Message);
//             //=========================
//             DateTime currentTime = DateTime.Now;
//             String fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

//             Screenshot screenshot = stepBase.GetDriver().TakeScreenshot();

//             string snapshotPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Snapshots/");

//             screenshot.SaveAsFile(Path.Combine(snapshotPath, fileName));
//             var fullpath = snapshotPath + fileName;
            
//             // Scenario.AddScreenCaptureFromPath(snapshotPath + fileName);
//             // _scenario.AddScreenCaptureFromPath("/Users/ravinder.budhawan/Desktop/Octopus/Automation/sampleProject/sampleProject/Snapshots/2025-05-16_09-42-50.jpg");
//     var mediaEntity =MediaEntityBuilder.CreateScreenCaptureFromPath(snapshotPath + fileName).Build();
// _scenario.Value
//                 .CreateNode(new GherkinKeyword(stepType), _scenarioContext.StepContext.StepInfo.Text)
//                 .Fail(_scenarioContext.TestError.Message, mediaEntity);
//     //==================================   
//         }
//     }

//     [AfterScenario]
//     public void AfterScenario()
//     {
//         // Cleanup if needed
//     }
// }





















using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using AventStack.ExtentReports.Gherkin;
using sampleProject.StepDefinitions;
using OpenQA.Selenium.Support.Extensions;
using log4net;
using log4net.Config;

[Binding]
public class ExtentReportHooks
{
    private static readonly object _lock = new object();
    private static ExtentReports _extent;
    private static ExtentSparkReporter _htmlReporter;

    // Stores one feature node per feature title
    private static ConcurrentDictionary<string, ExtentTest> _featureNodes = new ConcurrentDictionary<string, ExtentTest>();

    // Each thread gets its own scenario node
    private static ThreadLocal<ExtentTest> _scenarioNode = new ThreadLocal<ExtentTest>();
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;

    public ExtentReportHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        string reportPath = "./../../ExtentReports/ExtentReport.html";
        _htmlReporter = new ExtentSparkReporter(reportPath);
        _htmlReporter.Config.DocumentTitle = "Automation Report";
        _htmlReporter.Config.ReportName = "Reqnroll Parallel Execution";
      
        _extent = new ExtentReports();
        _extent.AttachReporter(_htmlReporter);
    }
         string featureTitle ;
        string scenarioTitle;

    [BeforeScenario]
    public void BeforeScenario()
    {
           var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            var v=new FileInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Support/log4net.config");
            XmlConfigurator.Configure(logRepository,new FileInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+"/Support/log4net.config"));
           
         featureTitle = _featureContext.FeatureInfo.Title;
         scenarioTitle = _scenarioContext.ScenarioInfo.Title;

        ExtentTest featureNode;

        // Lock to ensure only one thread creates the feature node
        lock (_lock)
        {
            if (!_featureNodes.ContainsKey(featureTitle))
            {
                featureNode = _extent.CreateTest<Feature>(featureTitle);
                _featureNodes.TryAdd(featureTitle, featureNode);
            }
            else
            {
                featureNode = _featureNodes[featureTitle];
            }
        }

        // Each scenario node is a child of its feature node
        _scenarioNode.Value = featureNode.CreateNode<Scenario>(scenarioTitle);
      
       
    }

    [AfterStep]
    public void AfterStep()
    {
        var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        var stepText = _scenarioContext.StepContext.StepInfo.Text;


  log.Info("Executing feature : " + featureTitle +".   Executing Scenario :"+ scenarioTitle+".                        Exectuting step" +stepText);
        if (_scenarioContext.TestError == null)
        {
            _scenarioNode.Value.CreateNode(new GherkinKeyword(stepType), stepText);
            log.Info("step pass " + stepText);
            
            
        }
        else
        {
            // var mediaEntity = CaptureScreenshotAndReturnModel(_scenarioContext.ScenarioInfo.Title);
            // _scenarioNode.Value
            //     .CreateNode(new GherkinKeyword(stepType), stepText)
            //     .Fail(_scenarioContext.TestError.Message, mediaEntity);

            log.Error("step fail " + stepText);
            //=========================
            DateTime currentTime = DateTime.Now;
            String fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";


            Screenshot screenshot = stepBase.GetDriver().TakeScreenshot();

            string snapshotPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Snapshots/");

            screenshot.SaveAsFile(Path.Combine(snapshotPath, fileName));
            var fullpath = snapshotPath + fileName;

            // Scenario.AddScreenCaptureFromPath(snapshotPath + fileName);
            // _scenario.AddScreenCaptureFromPath("/Users/ravinder.budhawan/Desktop/Octopus/Automation/sampleProject/sampleProject/Snapshots/2025-05-16_09-42-50.jpg");
            var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromPath(snapshotPath + fileName).Build();
            _scenarioNode.Value
                            .CreateNode(new GherkinKeyword(stepType), _scenarioContext.StepContext.StepInfo.Text)
                            .Fail(_scenarioContext.TestError.Message, mediaEntity);

        }
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        _extent.Flush();
    }



    [AfterScenario]
    public void AfterScenario()
    {
        // Optional: cleanup or flush scenario-specific logs
    }
}
