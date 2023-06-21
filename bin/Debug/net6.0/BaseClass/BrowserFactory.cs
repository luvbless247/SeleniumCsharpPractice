using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.CustomExcemption;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.BaseClass
{
    public class BrowserFactory
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("start-maximized");
            options.AcceptInsecureCertificates = true;
            return options;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            //  options.AddArgument("start-maximized");
            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions options = new EdgeOptions();
            // options.AddArgument("start-maximized");
            return options;
        }


        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetEdgeDriver()
        {
            IWebDriver driver = new EdgeDriver(GetEdgeOptions());
            return driver;
        }

        // public static IWebDriver CreateWebDriver()

        public static IWebDriver SelectBrowser()
        {
            try
            {

                //string browser = ConfigurationManager.AppSettings.Get("Browser");
                ObjectRepository.Config = new AppConfigReader();
                //string browser = ObjectRepository.Config.GetBrowser().ToString();

                switch (ObjectRepository.Config.GetBrowser())


                //switch (browser.ToLower())
                {
                    case BrowserType.chrome:
                        ObjectRepository.Driver = GetChromeDriver();
                        break;

                    // return   ObjectRepository.Driver = new ChromeDriver();

                    case BrowserType.firefox:
                        ObjectRepository.Driver = GetFirefoxDriver();
                        break;

                    //  return ObjectRepository.Driver = new FirefoxDriver();

                    case BrowserType.edge:
                        ObjectRepository.Driver = GetEdgeDriver();
                        break;

                        //   return ObjectRepository.Driver = new EdgeDriver();
                        //default:
                        // Default to Chrome if an invalid browser value is provided
                        //    throw new NoSuitableDriverFound(ObjectRepository.Config.GetBrowser());
                }
                ObjectRepository.Driver.Manage().Timeouts().PageLoad =
               TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());
                BrowserHelper.MaximiseBrowser();
                return ObjectRepository.Driver;



            }

            catch (Exception e)
            {
                if (e is ArgumentException)
                    throw new NoSuitableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
                throw;
            }

        }

        public static void stopBrowser()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}
