using SpecFlowPracticeTest.Interfaces;
using SpecFlowPracticeTest.Settings;
using System.Configuration;

namespace SpecFlowPracticeTest.Configuration
{
    public class AppConfigReader : IConfig
    {
        public string GetApp()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.App);
        }

        public BrowserType GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser.ToLower());
            //string browser = ConfigurationManager.AppSettings.Get("Browser");
            //BrowserType browserType;
            //if (Enum.TryParse(browser, true, out browserType))
            //{
            //    return browserType;
            //}
            //else
            //{
            //    // Return the default browser type from app.config
            //    if (Enum.TryParse(ConfigurationManager.AppSettings.Get("Browser"), true, out BrowserType defaultBrowserType))
            //    {
            //        return defaultBrowserType;
            //    }
            //    else
            //    {
            //        // If the default browser type is also invalid, throw an exception
            //        throw new NoSuitableDriverFound(BrowserType.UnsupportedBrowser);
            //    }
            //}

        }

        public int GetExplicitWaitTimeout()
        {
            string explicitWait = ConfigurationManager.AppSettings.Get(AppConfigKeys.ExplicitWaitTimeout);
            if (explicitWait == null)
                return 30;
            return Convert.ToInt32(explicitWait);
        }

        public int GetImplicitWaitTimeout()
        {
            string implicitWait = ConfigurationManager.AppSettings.Get(AppConfigKeys.ImplicitWaitTimeout);
            if (implicitWait == null)
                return 30;
            return Convert.ToInt32(implicitWait);
        }

        public string GetLink()
        {
            string link = ConfigurationManager.AppSettings.Get(AppConfigKeys.Link);
            return link;
        }

        public string GetOS()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.OS);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.password);
        }

        public string GetURL()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.URL);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.username);
        }

        public int GetPageLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);

        }
    }
}
