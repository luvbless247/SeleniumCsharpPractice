using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.PageObject;
using SpecFlowPracticeTest.Settings;



namespace SpecFlowPracticeTest.TestCases
{

    public class WaitTestImpExp
    {

        RegistrationPage obj;
        private IWebDriver driver;
        public WaitTestImpExp()
        {

            ObjectRepository.Driver = this.driver;

        }

        [Test]
        public void ExpTest()
        {

            BrowserFactory.SelectBrowser();

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetLink());
            obj = new RegistrationPage(ObjectRepository.Driver);

            obj.ClickRegister().Click();
            obj.ClickSetUp().Click();
            //Thread.Sleep(1000);
            //WaitHelperT.ImplicitWait();
            WebDriverWait wait = WaitHelperT.ExplicitWait();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(obj.ClickSignUp()));
            obj.EnterFullName().SendKeys("THANK YOU");
            BrowserFactory.stopBrowser();

        }
        [Test]
        public void ImpTest()
        {

            BrowserFactory.SelectBrowser();

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetLink());
            obj = new RegistrationPage(ObjectRepository.Driver);

            obj.ClickRegister().Click();
            obj.ClickSetUp().Click();
            //Thread.Sleep(1000);
            WaitHelperT.ImplicitWait();
            obj.EnterFullName().SendKeys("THANK YOU");
            BrowserFactory.stopBrowser();

        }
    }
}
