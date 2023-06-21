using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowPracticeTest.PageObject;
using SpecFlowPracticeTest.Settings;
using System.Configuration;


namespace SpecFlowPracticeTest.StepDefinitions
{
    [Binding]

    public class RegistrationPageSteps
    {
        //string uname = ConfigurationManager.AppSettings.Get("username");
        //string pass = ConfigurationManager.AppSettings.Get("password");

        private RegistrationPage rpage;
        private IWebDriver driver;
        public RegistrationPageSteps(IWebDriver driver)
        {
            this.driver = driver;
            ObjectRepository.Driver = this.driver;

        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {

            string url1 = ConfigurationManager.AppSettings.Get("Link");


            driver.Url = url1;

            rpage = new RegistrationPage(ObjectRepository.Driver);
            //WaitHelper.SetImplicitWait(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rpage.ClickRegister()));
            //Thread.Sleep(5000);


            // string actualPage=driver.Title;
            // Assert.AreEqual("", actualPage);
        }

        [When(@"I click on register")]
        public void WhenIClickOnRegister()
        {
            rpage.ClickRegister().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rpage.ClickSetUp()));

        }

        [Then(@"registration page is displayed")]
        public void ThenRegistrationPageIsDisplayed()
        {

            // TO DO

        }

        [Then(@"I click on sign up with email")]
        public void ThenIClickOnSignUpWithEmail()
        {
            rpage.ClickSetUp().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(rpage.ClickSignUp()));
        }

        [Then(@"Sign up page is displayed")]
        public void ThenSignUpPageIsDisplayed()
        {
            //TO DO
        }

        [Then(@"I enter full name")]
        public void ThenIEnterFullName()
        {
            rpage.EnterFullName().SendKeys("name");
        }

        [Then(@"I enter email")]
        public void ThenIEnterEmail()
        {
            rpage.EnterEmailAddress().SendKeys("name@name.com");
        }

        [Then(@"I enter password")]
        public void ThenIEnterPassword()
        {
            rpage.EnterPassword().SendKeys("pass");
        }

        [Then(@"I click on sign up button")]
        public void ThenIClickOnSignUpButton()
        {
            rpage.ClickSignUp().Click();
            Thread.Sleep(5000);
        }

        [Then(@"I should be register successfully")]
        public void ThenIShouldBeRegisterSuccessfully()
        {
            // TO DO
        }


    }
}
