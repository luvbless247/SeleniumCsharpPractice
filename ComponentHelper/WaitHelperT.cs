using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.Settings;
using System.Configuration;

namespace SpecFlowPracticeTest.ComponentHelper
{
    public class WaitHelperT
    {
        private IWebDriver driver;
        public static void ImplicitWait()
        {
            //ObjectRepository.Driver = driver;
            ObjectRepository.Config = new AppConfigReader();
            string timeoutInSeconds = ConfigurationManager.AppSettings.Get(AppConfigKeys.ImplicitWaitTimeout);
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt32(timeoutInSeconds));
        }

        public static WebDriverWait ExplicitWait()
        {
            //ObjectRepository.Driver = driver;
            ObjectRepository.Config = new AppConfigReader();
            string timeoutInSeconds = ConfigurationManager.AppSettings.Get(AppConfigKeys.ExplicitWaitTimeout);
            return new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(Convert.ToInt32(timeoutInSeconds)));
        }
    }
}
