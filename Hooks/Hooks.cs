using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.Hooks
{
    [Binding]
    /*   public sealed class Hooks
       {
           private readonly IObjectContainer _container;
           private static ExtentTest _feature;
           private static ExtentTest _scenario;

           public Hooks(IObjectContainer container)
           {
               _container = container;
           }

           [BeforeTestRun]
           public static void BeforeTestRun()
           {
               ExtentReport.ExtentReportInit();
           }

           [AfterTestRun]
           public static void AfterTestRun()
           {
               ExtentReport.ExtentReportTearDown();
           }

           [BeforeFeature]
           public static void BeforeFeature(FeatureContext featureContext)
           {
               _feature = ExtentReport.GetExtentReports().CreateTest<Feature>(featureContext.FeatureInfo.Title);
           }

           [AfterFeature]
           public static void AfterFeature()
           {
               // Perform any necessary actions after executing a feature
           }

           [BeforeScenario]
           public void BeforeScenario()
           {
               ExtentReport.StartBrowser();
               _container.RegisterInstanceAs(ExtentReport.GetDriver());
           }

           [AfterScenario]
           public void AfterScenario()
           {
               ExtentReport.CloseBrowser();
           }

           [BeforeStep]
           public void BeforeStep(ScenarioContext scenarioContext)
           {
               string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
               string stepName = scenarioContext.StepContext.StepInfo.Text;

               switch (stepType)
               {
                   case "Given":
                       _scenario = _feature.CreateNode<Given>(stepName);
                       break;
                   case "When":
                       _scenario = _feature.CreateNode<When>(stepName);
                       break;
                   case "Then":
                       _scenario = _feature.CreateNode<Then>(stepName);
                       break;
                   case "And":
                       _scenario = _feature.CreateNode<And>(stepName);
                       break;
               }
           }

           [AfterStep]
           public void AfterStep(ScenarioContext scenarioContext)
           {
               if (scenarioContext.TestError != null)
               {
                   _scenario.Fail(scenarioContext.TestError.Message)
                       .AddScreenCaptureFromPath(ExtentReport.AddScreenshot(ExtentReport.GetDriver(), scenarioContext));
               }
           }
       }*/

    public sealed class Hooks : ExtentReport
    {
        // IWebDriver driver;
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before testrun...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after testrun...");
            ExtentReportTearDown();
            // SendReportByEmail();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Runnin before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            startBrowser();

            _container.RegisterInstanceAs<IWebDriver>(ObjectRepository.Driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");
            closeBrowser();
            // _container.RegisterInstanceAs<IWebDriver>(ObjectRepository.Driver);
            //var driver = _container.Resolve<IWebDriver>();
            //if (driver != null)
            //{
            //    driver.Quit();
            //}
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step...");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            //var driver = _container.Resolve<IWebDriver>();


            //When scenario passed

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }

                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }

                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }
            //When scenario fails
            if (scenarioContext.TestError != null)
            {


                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(ObjectRepository.Driver, scenarioContext)).Build());

                }

                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(ObjectRepository.Driver, scenarioContext)).Build());
                }

                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(ObjectRepository.Driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(ObjectRepository.Driver, scenarioContext)).Build());
                }

            }
        }
    }
}