using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowPracticeTest.BaseClass;
using SpecFlowPracticeTest.ComponentHelper;
using SpecFlowPracticeTest.Configuration;
using SpecFlowPracticeTest.Settings;

namespace SpecFlowPracticeTest.TestCases
{
    public class ComboSearchTextBox
    {
        [Test]
        public static void TestBoxes()
        {
            ObjectRepository.Config = new AppConfigReader();
            BrowserFactory.SelectBrowser();
            BrowserHelper.MaximiseBrowser();
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetURL());

            string mss = TextHelper.GetAttributeValue(By.CssSelector("#signInBtn"));
            IWebElement ele1 = ObjectRepository.Driver.FindElement(By.CssSelector(".blinkingText"));


            string me1 = ele1.Text;


            Console.WriteLine(mss);
            Console.WriteLine(me1);
            SearchBoxHelper.SearchBox(By.XPath("//input[@id='username']"), "USERNAME");
            Thread.Sleep(1000);
            ComboBoxHelper.SelectElementByText(By.XPath("//select[@class='form-control']"), "Consultant");
            Thread.Sleep(1000);
            ComboBoxHelper.SelectElementByIndex(By.XPath("//select[@class='form-control']"), 1);
            Thread.Sleep(1000);

            foreach (string str in ComboBoxHelper.GetAllItem(By.XPath("//select[@class='form-control']")))
            {
                Console.WriteLine("Test are : {0} ", str);
            }
            BrowserFactory.stopBrowser();
        }
    }
}
