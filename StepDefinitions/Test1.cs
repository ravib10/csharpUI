using System;
using NUnit.Framework;
using Reqnroll;
	
	namespace sampleProject.StepDefinitions
	{
		[Binding]
		public class Test1
		{
			private readonly ScenarioContext _scenarioContext;
	
			public Test1(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
[Given(@"write a message")]
public void Givenwriteamessage()
{
	TestContext.Progress.WriteLine("ha ha");
	Console.WriteLine("ha ha");
}

		}
	}