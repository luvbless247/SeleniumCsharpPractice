using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.PageObject;
using SpecFlowPracticeTest.Settings;
//[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace SpecFlowPracticeTest.StepDefinitions
{

    [Binding]
    public class LoginSteps

    {
        private IWebDriver driver;
        private bool loginSuccessful;
        private LoginPage loginPage;


        public LoginSteps(IWebDriver driver)
        {
            this.driver = driver;
            ObjectRepository.Driver = this.driver;


        }


        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            ObjectRepository.Config = new AppConfigReader();

            Assert.AreEqual("LoginPage Practise | Rahul Shetty Academy", WindowHelper.GetTile());

            Console.WriteLine(WindowHelper.GetTile());
            loginPage = new LoginPage(ObjectRepository.Driver);



        }

        [When(@"I enter ""([^""]*)"" and ""([^""]*)""")]
        public void WhenIEnterAnd(string uname, string pass)
        {

            loginPage.Enterusername(uname);
            Thread.Sleep(1000);
            loginPage.Enterpassword(pass);
            Thread.Sleep(1000);
        }

        [When(@"I click on terms and conditions")]
        public void WhenIClickOnTermsAndConditions()
        {

            loginPage.ClickTermsAndConditions();
            Thread.Sleep(1000);
        }

        [When(@"I click on submit button")]
        public void WhenIClickOnSubmitButton()
        {

            loginPage.ClickSubmitButton();
            Thread.Sleep(2000);

        }


        [Then(@"I ""([^""]*)"" be logged in successfully")]
        public void ThenIBeLoggedInSuccessfully(string loginStatus)
        {

            loginSuccessful = loginStatus.Equals("should");
            if (loginSuccessful)
            {

                // string title = ObjectRepository.Driver.Title;
                Assert.AreEqual("ProtoCommerce", WindowHelper.GetTile());
                Console.WriteLine(WindowHelper.GetTile());


            }
            else
            {
                //string loginTitle = WindowHelper.GetTile();
                //ObjectRepository.Driver.Title;
                Assert.AreEqual("LoginPage Practise | Rahul Shetty Academy", WindowHelper.GetTile());
                string expectedResult = "Incorrect username/password1.";
                string actualResult = loginPage.GetTextt().Text;
                Assert.AreEqual(@expectedResult, actualResult);
            }

        }
    }
}
