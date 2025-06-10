using System;
using System.Configuration;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using ExecuteAutomation.Reqnroll.Dynamics;
using log4net;
using log4net.Config;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using Reqnroll;
using Reqnroll.Bindings;
using sampleProject.Pages;
// using sampleProject.Hooks;


namespace sampleProject.StepDefinitions
	{
		[Binding]
		public class stepDefinitions : stepBase
		{
			// private readonly ScenarioContext _scenarioContext;
          
	
			public stepDefinitions()
			{
				// _scenarioContext = scenarioContext;
               
      
         
			}
			

 String siteUrl;
    String submitPageUrl;
    String returnToIndexPageUrl;
    HomePage home;
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [BeforeScenario]
        public void before()
        {
        
            // this._scenarioContext = scenario1;
            Console.WriteLine("he he he");
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            var v = new FileInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Support/log4net.config");
            XmlConfigurator.Configure(logRepository, new FileInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Support/log4net.config"));
            log.Info("yuppie");
        
            

    }


			 public void initialise() {
       
            siteUrl = ConfigurationManager.AppSettings["siteUrl"];
            submitPageUrl = ConfigurationManager.AppSettings["submitPageUrl"];
            returnToIndexPageUrl = ConfigurationManager.AppSettings["returnToIndex"];

        home = new HomePage();
    

    }

[AfterScenario]
    public static void tearDown(ScenarioContext scenario) {


     if (GetDriver() != null) {
            GetDriver().Quit();
        }


        // extent.Flush();
    }



    [Given(@"I am on the Home Page of test Website")]
public void GivenIamontheHomePageoftestWebsite()
{
	openUrl(siteUrl);
}

        [Given(@"I open (.*) browser")]
        public void GivenIopenbrowser(string browser)
        {
            openBrowser(browser);
            initialise();
}


[Then(@"Verify following are appearing on the page or not")]
public void ThenVerifyfollowingareappearingonthepageornot(Table fieldName)
{
    //dynamic data=fieldName.CreateDynamicSet();
    
    foreach(var item in fieldName.Rows){
        Console.WriteLine("item is "+item["Fields"]);
        // Assert.IsTrue(home.validateFieldsPresence(item),item + " field is not appearing on the page");
        Assert.That(home.validateFieldsPresence(item["Fields"]),item["Fields"] + " field is not appearing on the page");
    }
	
}


[Given(@"Verify if ""(.*)"" button is appearing")]
public void GivenVerifyifbuttonisappearing(string buttonName)
{
Assert.That(home.validateFieldsPresence(buttonName));
}

[Given(@"Verify if ""(.*)"" link is appearing")]
public void GivenVerifyiflinkisappearing(string linkName)
{
    Console.Write("inside partiallink butotn");
Assert.That(home.validateLinkPresence(linkName));
}



    // This step definition uses Cucumber Expressions. See https://github.com/gasparnagy/CucumberExpressions.SpecFlow
    [Then(@"Verify following radio buttons are appearing on the page or not")]
    public void ThenVerifyFollowingRadioButtonsAreAppearingOnThePageOrNot(Table fieldName)
    {
        Console.Write("inside radio butotn");
      //dynamic data=fieldName.CreateDynamicSet();
 foreach(var item in fieldName.Rows){
      Console.WriteLine("item1 is "+item["RadioButtons"]);
        Assert.That(home.validateRadioCheckboxButtonPresence(item["RadioButtons"]),item["RadioButtons"] + " field is not appearing on the page");
    }
    }



    [Then(@"Verify following check box buttons are appearing on the page or not")]
    public void ThenVerifyFollowingCheckBoxButtonsAreAppearingOnThePageOrNot(Table fieldName)
    {
   Console.Write("inside check butotn");
 foreach(var item in fieldName.Rows){
    
        Assert.That(home.validateRadioCheckboxButtonPresence(item["Checkboxes Names"]),item["Checkboxes Names"] + " field is not appearing on the page");
    }
    }


  [Then(@"i am testing it")]
    public void Iamtestingit()
    {
        //in reqnroll, pending or skipped steps doesn't fall in executed step hence afterstep won't consider as a step and it
        // will always appear as pass. to make it fail, throw new Exception("your message");
throw new PendingStepException("This step is intentionally skipped because ");
    }
		}
    }