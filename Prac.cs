using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.Settings;
using System.Configuration;

namespace SpecFlowPracticeTest
{

    public class Prac
    {


        IWebDriver driver;

        [Test]
        public void TestMe()
        {



            Console.WriteLine();
            ObjectRepository.Config = new AppConfigReader();
            ObjectRepository.Driver = driver;
            string url = ObjectRepository.Config.GetURL();
            string username = ObjectRepository.Config.GetUsername();
            string password = ObjectRepository.Config.GetPassword();
            string link = ObjectRepository.Config.GetLink();
            string browser = ObjectRepository.Config.GetBrowser().ToString();
            Console.WriteLine(url);
            Console.WriteLine(username);
            Console.WriteLine(password);
            Console.WriteLine(link);
            Console.WriteLine(browser);
            Console.WriteLine("************************************");
            string ur = ConfigurationManager.AppSettings.Get("URL");
            string user = ConfigurationManager.AppSettings.Get("username");
            string pass = ConfigurationManager.AppSettings.Get("password");
            string lin = ConfigurationManager.AppSettings.Get("Link");
            string brow = ConfigurationManager.AppSettings.Get("Browser");
            Console.WriteLine(ur);
            Console.WriteLine(user);
            Console.WriteLine(pass);
            Console.WriteLine(lin);
            Console.WriteLine(brow);


        }
    }
}
