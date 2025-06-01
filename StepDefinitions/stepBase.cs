using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;
using sampleProject.Constants;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;
using Reqnroll;
using log4net;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace sampleProject.StepDefinitions;

public class stepBase
{
        public static ThreadLocal<IWebDriver> driver = new();
        private static ExtentReports extent;
        //public static ThreadLocal<ExtentTest> exTest = new();
         private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
 static int TIMEOUT = 30;
 static int PAGE_LOAD_TIMEOUT = 30;


public void openBrowser(String browserType) {
    // browserType = TestContext.Parameters["browser"] ?? "chrome";
    //if you want to read values from config (launch.json) file, then use following command
    //  browserType = Environment.GetEnvironmentVariable("browser")??"chrome";
          //if you want to run a test and pass browser value through commandline, then use following 
    browserType = TestContext.Parameters.Get("browser", browserType);
    // if (browserType == null)
    //     browserType = ConfigurationManager.AppSettings["browser"];
    // Console.WriteLine("value is " + browserType);
    switch (browserType)
    {
      case "chrome":
        // new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        new DriverManager().SetUpDriver(new ChromeConfig());
        driver.Value = new ChromeDriver();
        Console.WriteLine("value is " + browserType);
        break;
      case "firefox":

        driver.Value = new FirefoxDriver();
        Console.WriteLine("value is " + browserType);
        break;

    }
          Console.WriteLine("value is " + browserType);


        // setWebDriver(driver.Value);

        GetDriver().Manage().Window.Maximize();
        GetDriver().Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(TIMEOUT);
        GetDriver().Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(PAGE_LOAD_TIMEOUT);

    }
   public static IWebDriver GetDriver()
        {

            return driver.Value;
        }

    // public static void setWebDriver(IWebDriver driver1) {

    //     driver=driver1;
    // }

    public void openUrl(String url){
        //TestContext.Progress.WriteLine("ho ho");
        Console.WriteLine("ho ho url : "+url);
        GetDriver().Url=url;

    }



}












// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using System;
// using System.Threading;
// using WebDriverManager;
// using WebDriverManager.DriverConfigs.Impl;
// using NUnit.Framework;

// namespace sampleProject.StepDefinitions;

// [SetUpFixture]
// public class TestSetup
// {
//     public static ExtentReports extent;

//     [OneTimeSetUp]
//     public void GlobalSetup()
//     {
//         var htmlReporter = new ExtentSparkReporter("TestReport.html");
//         extent = new ExtentReports();
//         extent.AttachReporter(htmlReporter);
//     }

//     [OneTimeTearDown]
//     public void GlobalTearDown()
//     {
//         extent.Flush(); // Write all results to the report
//     }
// }

// public class stepBase
// {
//     public static ThreadLocal<IWebDriver> driver = new();
//     public static ThreadLocal<ExtentTest> exTest = new();

//     private const int TIMEOUT = 30;
//     private const int PAGE_LOAD_TIMEOUT = 30;

//     [SetUp]
//     public void openBrowser(String browser)
//     {
//         // Initialize ChromeDriver per thread
//         new DriverManager().SetUpDriver(new ChromeConfig());
//         driver.Value = new ChromeDriver();

//         GetDriver().Manage().Window.Maximize();
//         GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT);
//         GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PAGE_LOAD_TIMEOUT);

//         // Create ExtentTest instance for this test thread
//         string testName = TestContext.CurrentContext.Test.Name;
//         exTest.Value =TestSetup.extent.CreateTest(testName);
//          //exTest.Value = TestSetup.extent.CreateTest(testName);
//     }

//     public static IWebDriver GetDriver() => driver.Value;

//     public void openUrl(string url)
//     {
//         GetDriver().Url = url;
//         exTest.Value.Info("Opening URL: " + url);
//     }

//     [TearDown]
//     public void TearDown()
//     {
//         var status = TestContext.CurrentContext.Result.Outcome.Status;
//         var errorMsg = TestContext.CurrentContext.Result.Message;

//         switch (status)
//         {
//             case NUnit.Framework.Interfaces.TestStatus.Failed:
//                 exTest.Value.Fail("Test Failed: " + errorMsg);
//                 break;
//             case NUnit.Framework.Interfaces.TestStatus.Passed:
//                 exTest.Value.Pass("Test Passed");
//                 break;
//             default:
//                 exTest.Value.Warning("Test status: " + status);
//                 break;
//         }

//         if (GetDriver() != null)
//         {
//             GetDriver().Quit();
//         }
//     }
// }


















// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter.Config;
// using AventStack.ExtentReports.Reporter;
// using log4net;
// using OpenQA.Selenium;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.Extensions.Configuration;
// using AventStack.ExtentReports.MarkupUtils;
// using NUnit.Framework.Interfaces;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Firefox;
// using OpenQA.Selenium.Remote;
// using OpenQA.Selenium.Support.Extensions;
// using System.IO;
// using NUnit.Framework;
// using System.Threading;
// using WebDriverManager;
// using WebDriverManager.DriverConfigs.Impl;

// namespace sampleProject.StepDefinitions
// {
//     [SetUpFixture]
//     public class stepBase
//     {
//         /*
//          * Extent Reports
//          * Logs
//          * Database
//          * Keywords
//          * Screenshots
//          * WebDriver
//          * Configuration
//          * Grid
//          * ThreadLocal
//          * 
//          */

//         public static ThreadLocal<IWebDriver> driver = new();
//         private static ExtentReports extent;
//         public static ThreadLocal<ExtentTest> exTest = new();

//         private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//         private IConfiguration configuration;
//         private static string fileName;
        

//         public static IWebDriver GetDriver()
//         {

//             return driver.Value;
//         }


//         public static ExtentTest GetExtentTest()
//         {


//             return exTest.Value;
//         }

//         static stepBase()
//         {
//             DateTime currentTime = DateTime.Now;
//             string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";
//             extent = CreateInstance(fileName);


//         }

//         [OneTimeSetUp]
//         public void OneTimeSetup()
//         {

//             log.Info("Test Execution Started !!!");
          
//             configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\")
//                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                 .Build();
//         }

//         [SetUp]
//         public void BeforeEachTest()
//         {

//             exTest.Value = extent.CreateTest(TestContext.CurrentContext.Test.ClassName+" @ Test Case Name : "+TestContext.CurrentContext.Test.Name);

//         }


//         [TearDown]
//         public void AfterEachTest()
//         {
//             //Get the test status
//             var testStatus = TestContext.CurrentContext.Result.Outcome.Status;



//             if (testStatus == TestStatus.Passed)
//             {
//                 GetExtentTest().Pass("Test case pass");
//                 IMarkup markup = MarkupHelper.CreateLabel("PASS", ExtentColor.Green);
//                 GetExtentTest().Pass(markup);

//             }
//             else if (testStatus == TestStatus.Skipped)
//             {
//                 GetExtentTest().Skip("Test Skipped : " + TestContext.CurrentContext.Result.Message);
//                 IMarkup markup = MarkupHelper.CreateLabel("SKIP", ExtentColor.Amber);
//                 GetExtentTest().Skip(markup);
//             }
//             else if (testStatus == TestStatus.Failed)
//             {


//                 CaptureScreenshot();

//                 GetExtentTest().Fail("Test Failed : " + TestContext.CurrentContext.Result.Message);
//                 GetExtentTest().Fail("<b><font color=red>  Screenshot of failure </font></b><br>", MediaEntityBuilder.CreateScreenCaptureFromPath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\screenshots\\" + fileName).Build());
//                 IMarkup markup = MarkupHelper.CreateLabel("FAIL", ExtentColor.Red);
//                 GetExtentTest().Fail(markup);
//             }

//             if(driver.Value != null)
//             {

//                 GetDriver().Quit();
//             }

//         }


//         private void CaptureScreenshot()
//         {

//             DateTime currentTime = DateTime.Now;
//             fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

//             Screenshot screenshot = GetDriver().TakeScreenshot();
//             screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "screenshots" + fileName);


//         }



//         private dynamic GetBrowserOptions(string browserName)
//         {

//             switch ("chrome")
//             {

//                 case "chrome":
//                     return new ChromeOptions();
//                 case "firefox":
//                     return new FirefoxOptions();


//             }

//             return new ChromeOptions();
//         }


//         public void SetUp(string browserName)
//         {
//             dynamic options = GetBrowserOptions(browserName);
//             options.PlatformName = "windows";



//             driver.Value = new RemoteWebDriver(new Uri(configuration["AppSettings:gridurl"]), options.ToCapabilities());
            
//             GetDriver().Url = configuration["AppSettings:testsiteurl"];
//             GetDriver().Manage().Window.Maximize();
//             GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(configuration["AppSettings:implicit.wait"]));
//         }



//         [OneTimeTearDown]
//         public void OneTimeTearDown()
//         {

//             extent.Flush();
//             if (driver == null) { 
            
//             driver.Dispose();
//             exTest.Dispose();
//             log.Info("Test execution completed !!!");
//             }
//         }

//         public static ExtentReports CreateInstance(string fileName)
//         {


//             var htmlReporter = new ExtentSparkReporter(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "//reports//" + fileName);
//             htmlReporter.Config.Theme = Theme.Standard;
//             htmlReporter.Config.DocumentTitle = "Way2Automation Test Suite";
//             htmlReporter.Config.ReportName = "Automation Test Results";
//             htmlReporter.Config.Encoding = "utf-8";

//             extent = new ExtentReports();
//             extent.AttachReporter(htmlReporter);

//             extent.AddSystemInfo("Automation Tester", "Rahul Arora");
//             extent.AddSystemInfo("Organization", "Way2Automation");
//             extent.AddSystemInfo("Build No: ", "W2A-1234");

//             return extent;
//         }
//             public void openUrl(String url){
//         //TestContext.Progress.WriteLine("ho ho");
//         Console.WriteLine("ho ho url : "+url);
//         GetDriver().Url=url;

//     }
//     public void openBrowser(String browserType) {

//         switch(browserType) {
//             case Constants.Constants.chromeBrowser:
//             new DriverManager().SetUpDriver(new ChromeConfig());
//                 driver.Value = new ChromeDriver();
//                 break;

//         }
//     }


//     }
// }
