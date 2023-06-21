using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowPracticeTest.Settings;
using System.Configuration;

namespace SpecFlowPracticeTest.WaitTime
{
    public static class WaitHelper

    {
        public static void TestImplicitWait()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait =
                         (TimeSpan.FromSeconds(ObjectRepository.Config.GetImplicitWaitTimeout()));
        }
        public static TimeSpan SetImplicitWait(IWebDriver driver)
        {
            TimeSpan implicitWaitTimeout = GetImplicitWaitTimeoutFromConfig();
            driver.Manage().Timeouts().ImplicitWait = implicitWaitTimeout;
            return implicitWaitTimeout;
        }

        private static TimeSpan GetImplicitWaitTimeoutFromConfig()
        {
            string implicitWaitTimeoutStr = ConfigurationManager.AppSettings.Get(AppConfigKeys.ImplicitWaitTimeout);
            if (TimeSpan.TryParse(implicitWaitTimeoutStr, out TimeSpan implicitWaitTimeout))
            {
                return implicitWaitTimeout;
            }
            else
            {
                // Set a default implicit wait timeout value if parsing fails
                return TimeSpan.FromSeconds(30);
            }
        }

        public static TimeSpan SetExplicitWait(IWebDriver driver)
        {
            TimeSpan explicitWaitTimeout = GetExplicitWaitTimeoutFromConfig();
            WebDriverWait wait = new WebDriverWait(driver, explicitWaitTimeout);
            return explicitWaitTimeout;
        }

        private static TimeSpan GetExplicitWaitTimeoutFromConfig()
        {
            string explicitWaitTimeoutStr = ConfigurationManager.AppSettings.Get(AppConfigKeys.ExplicitWaitTimeout);
            if (TimeSpan.TryParse(explicitWaitTimeoutStr, out TimeSpan explicitWaitTimeout))
            {
                return explicitWaitTimeout;
            }
            else
            {
                // Set a default explicit wait timeout value if parsing fails
                return TimeSpan.FromSeconds(30);
            }
        }
    }
}
